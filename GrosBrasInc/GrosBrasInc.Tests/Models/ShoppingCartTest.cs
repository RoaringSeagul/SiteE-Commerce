using GrosBrasInc.Controllers;
using GrosBrasInc.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;

namespace GrosBrasInc.Tests.Models
{
    /// <summary>
    /// Auteur: Jonathan Koch-Roy
    /// Date: 
    /// Description: 
    /// </summary>
    [TestFixture]
    class ShoppingCartTest
    {
        public readonly PanierController controller = new PanierController();
        [OneTimeSetUp]
        public void Init()
        {
            HttpContextManager.SetCurrentContext(GetMockedHttpContext());
        }
        /*
            Manque de connaissance pour tester les context
        */
        [Test]
        public void ShouldGetCartItemsAvec1Objet()
        {
            // Arrange
            var data = new List<Panier>
            {
                new Panier
                {
                    PanierID = 1,
                    Count = 2,
                    DateCreated = DateTime.Now,
                    KeyPanier = "testGUID",
                    Article = new Article()
                    {
                        ArticleID = 1,
                        Categorie = new Categorie() { CategorieID = 1, NomCategorie = "testCategorie" },
                        Description = "Test Description",
                        NomArticle = "Test Article",
                        Prix = 12.99f
                    }
                }
            };

            // Act
            var sut = new Mock<ShoppingCart>();
            sut.Setup(x => x.GetCartItems()).Returns(data);


            // Assert
            Assert.IsTrue(Equals(sut.Object.GetCartItems(), data));
        }

        [Test]
        public void ShouldGetCartCountEqual1()
        {
            // Arrange
            var data = new List<Panier>
            {
                new Panier
                {
                    PanierID = 1,
                    Count = 2,
                    DateCreated = DateTime.Now,
                    KeyPanier = "testGUID",
                    Article = new Article()
                    {
                        ArticleID = 1,
                        Categorie = new Categorie() { CategorieID = 1, NomCategorie = "testCategorie" },
                        Description = "Test Description",
                        NomArticle = "Test Article",
                        Prix = 12.99f
                    }
                }
            };

            // Act
            var sut = new Mock<ShoppingCart>();
            sut.Setup(x => x.GetCount()).Returns(1);


            // Assert
            Assert.IsTrue(Equals(sut.Object.GetCount(), 1));
        }

        [Test]
        public void ShouldGetCartIDEqualsTest()
        {
            // Arrange
            var sut = new Mock<ShoppingCart>();
            sut.Setup(x => x.GetCartId(HttpContextManager.Current)).Returns("Test");


            // Assert
            Assert.IsTrue(Equals(sut.Object.GetCartId(HttpContextManager.Current), "Test"));
        }

        private HttpContextBase GetMockedHttpContext()
        {
            var fakeIdentity = new GenericIdentity("FakeBobby");
            var principal = new GenericPrincipal(fakeIdentity, null);
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s.SessionID).Returns(Guid.NewGuid().ToString());
            var server = new Mock<HttpServerUtilityBase>();
            var urlHelper = new Mock<UrlHelper>();

            var routes = new RouteCollection();
            //MvcApplication.RegisterRoutes(routes);
            var requestContext = new Mock<RequestContext>();
            requestContext.Setup(x => x.HttpContext).Returns(context.Object);
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            context.Setup(ctx => ctx.User).Returns(principal);
            context.Setup(ctx => ctx.Session[ShoppingCart.CartSessionKey]).Returns("TestGUID");
            context.Setup(ctx => ctx.User.Identity.Name).Returns("FakeBobby");
            context.Setup(ctx => ctx.User.Identity.IsAuthenticated).Returns(true);
            request.Setup(req => req.Url).Returns(new Uri("http://www.google.com"));
            request.Setup(req => req.RequestContext).Returns(requestContext.Object);
            requestContext.Setup(x => x.RouteData).Returns(new RouteData());
            context.SetupGet(x => x.Request).Returns(request.Object);
            request.SetupGet(req => req.Headers).Returns(new NameValueCollection());
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            return context.Object;
        }
    }
}

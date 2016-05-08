using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrosBrasInc.EstimatingProxy;
using System.Net;
using GrosBrasInc.Models;

namespace Module.Models
{
    public class PurolatorShippingLogic
    {
        Box _box;
        Order _order;

        private EstimatingService CreateEstimatingService()
        {
            EstimatingService service = new EstimatingService();

            // Setup the credentials for basic authentication
            //TODO : Define the Production (or development) Key and Password
            service.Credentials = new NetworkCredential("866a42afd41d439691ad19d80a214751", "Y4%rlkfL");

            // Set the request's context values
            service.RequestContextValue = new RequestContext();
            service.RequestContextValue.Version = "1.4";
            service.RequestContextValue.Language = Language.en;
            service.RequestContextValue.GroupID = "";
            service.RequestContextValue.RequestReference = "RequestReference";

            return service;
        }

        public GetQuickEstimateResponseContainer CallGetQuickEstimate(Box b, string PostalCode)
        {
            EstimatingService service = CreateEstimatingService();
            GetQuickEstimateRequestContainer request = new GetQuickEstimateRequestContainer();
            GetQuickEstimateResponseContainer response = new GetQuickEstimateResponseContainer();

            // Setup the request to perform a create shipment
            //TODO : Define the Billing account and the account that is registered with PWS
            request.BillingAccountNumber = "9999999999";
            //TODO : Populate the Origin Information
            request.SenderPostalCode = "J2S1H9";
            //TODO : Populate the Desination Information
            request.ReceiverAddress = new ShortAddress();
            request.ReceiverAddress.City = "";
            request.ReceiverAddress.Country = "CA";
            request.ReceiverAddress.Province = "QC";
            request.ReceiverAddress.PostalCode = PostalCode;
            request.PackageType = "ExpressBox";
            request.TotalWeight = new TotalWeight();
            request.TotalWeight.Value = Convert.ToInt32(b.WeightLb);
            request.TotalWeight.WeightUnit = WeightUnit.lb;

            try
            {
                // Call the service
                response = service.GetQuickEstimate(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" EXCEPTION: {0}", ex.Message);
            }

            return response;
        }

        public GetFullEstimateResponseContainer CallGetFullEstimate(Box b, Order o)
        {
            _box = b;
            _order = o;
            EstimatingService service = CreateEstimatingService();
            GetFullEstimateRequestContainer request = new GetFullEstimateRequestContainer();
            GetFullEstimateResponseContainer response = new GetFullEstimateResponseContainer();

            request.Shipment = CreateShipment();

            try
            {
                // Call the service
                response = service.GetFullEstimate(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" EXCEPTION: {0}", ex.Message);
            }

            return response;
        }

        private Shipment CreateShipment()
        {
            Shipment shipment = new Shipment();

            shipment.InternationalInformation = new InternationalInformation();
            shipment.InternationalInformation.CustomsInvoiceDocumentIndicator = true;
            shipment.InternationalInformation.ImportExportType = ImportExportType.Permanent;

            shipment.InternationalInformation.ContentDetails = new ContentDetail[1];
            shipment.InternationalInformation.ContentDetails[0] = new ContentDetail();
            shipment.InternationalInformation.ContentDetails[0].FDADocumentIndicator = true;
            shipment.InternationalInformation.ContentDetails[0].FCCDocumentIndicator = true;
            shipment.InternationalInformation.ContentDetails[0].NAFTADocumentIndicator = true;
            shipment.InternationalInformation.ContentDetails[0].SenderIsProducerIndicator = true;
            shipment.InternationalInformation.ContentDetails[0].TextileIndicator = true;

            shipment.SenderInformation = new SenderInformation();
            shipment.SenderInformation.Address = SetSenderAddress();
            shipment.SenderInformation.TaxNumber = "123456";

            shipment.ReceiverInformation = new ReceiverInformation();
            shipment.ReceiverInformation.Address = SetReceiverAddress();
            shipment.ReceiverInformation.TaxNumber = "654321";

            DateTime dt = DateTime.Now.AddDays(1.00);
            shipment.ShipmentDate = dt.ToString("yyyy-MM-dd");

            shipment.PackageInformation = new PackageInformation();
            shipment.PackageInformation.ServiceID = "PurolatorExpressEnvelope";
            shipment.PackageInformation.Description = "A thing";
            shipment.PackageInformation.TotalWeight = new TotalWeight();
            shipment.PackageInformation.TotalWeight.Value = Convert.ToInt32(_box.WeightLb);
            shipment.PackageInformation.TotalWeight.WeightUnit = WeightUnit.lb;
            shipment.PackageInformation.TotalPieces = 1;

            shipment.PackageInformation.PiecesInformation = new Piece[1];
            shipment.PackageInformation.PiecesInformation[0] = SetPiece(_box);
            shipment.PackageInformation.DangerousGoodsDeclarationDocumentIndicator = false;

            shipment.PackageInformation.OptionsInformation = SetOriginSignatureNotRequiredOption();

            shipment.PaymentInformation = new PaymentInformation();
            shipment.PaymentInformation.PaymentType = PaymentType.Sender;
            shipment.PaymentInformation.RegisteredAccountNumber = "9999999999";
            shipment.PaymentInformation.BillingAccountNumber = "9999999999";

            shipment.PickupInformation = new PickupInformation();
            shipment.PickupInformation.PickupType = PickupType.DropOff;

            shipment.NotificationInformation = new NotificationInformation();
            shipment.NotificationInformation.ConfirmationEmailAddress = "my.name@example.com";

            shipment.TrackingReferenceInformation = new TrackingReferenceInformation();
            shipment.TrackingReferenceInformation.Reference1 = "Reference1";
            shipment.TrackingReferenceInformation.Reference2 = "Reference2";
            shipment.TrackingReferenceInformation.Reference3 = "Reference3";
            shipment.TrackingReferenceInformation.Reference4 = "Reference4";

            shipment.OtherInformation = null;

            return shipment;
        }

        private OptionsInformation SetOriginSignatureNotRequiredOption()
        {
            OptionsInformation opt = new OptionsInformation();
            opt.Options = new OptionIDValuePair[1];
            opt.Options[0] = new OptionIDValuePair();
            opt.Options[0].ID = "OriginSignatureNotRequired";
            opt.Options[0].Value = "true";
            return opt;
        }

        private Piece SetPiece(Box b)
        {
            Piece piece = new Piece();

            piece.Weight = new Weight();
            piece.Weight.Value = Convert.ToDecimal(b.WeightLb);
            piece.Weight.WeightUnit = WeightUnit.lb;

            piece.Length = b.Length;
            piece.Width = b.Width;
            piece.Height = b.Height;

            return piece;
        }

        private Address SetReceiverAddress()
        {
            Address addr = new Address();

            addr.Name = _order.FirstName + " " + _order.LastName;
            addr.Company = _order.Company;
            addr.Department = _order.Departement;
            addr.StreetNumber = _order.StreetNumber.ToString();
            addr.StreetSuffix = "";
            addr.StreetName = _order.StreetName;
            addr.StreetType = _order.StreetType;
            addr.StreetDirection = "";
            addr.Suite = _order.Suite;
            addr.Floor = _order.Floor.ToString();
            addr.StreetAddress2 = _order.StreetAddress2;
            addr.StreetAddress3 = _order.StreetAddress3;
            addr.City = _order.City;
            addr.Province = _order.Province;
            addr.Country = _order.Country;
            addr.PostalCode = _order.PostalCode;
            addr.PhoneNumber = SetPhoneNumber(_order.PhoneNumber);
            addr.FaxNumber = SetPhoneNumber();

            return addr;
        }

        private Address SetSenderAddress()
        {

            Address addr = new Address();

            addr.Name = "Jonathan Koch-Roy";
            addr.Company = "GrosBrasInc";
            addr.Department = "Production";
            addr.StreetNumber = "3000";
            addr.StreetSuffix = "";
            addr.StreetName = "Boulé";
            addr.StreetType = "street";
            addr.StreetDirection = "";
            addr.Suite = "";
            addr.Floor = "";
            addr.StreetAddress2 = "";
            addr.StreetAddress3 = "";
            addr.City = "Saint-Hyacinthe";
            addr.Province = "QC";
            addr.Country = "CA";
            addr.PostalCode = "J2S 1H9";
            addr.PhoneNumber = SetPhoneNumber("1-514-5164131");
            addr.FaxNumber = SetPhoneNumber();

            return addr;
        }

        private PhoneNumber SetPhoneNumber()
        {
            PhoneNumber ph = new PhoneNumber();
            ph.CountryCode = "0";
            ph.AreaCode = "000";
            ph.Phone = "0000";
            ph.Extension = "";
            return ph;
        }

        private PhoneNumber SetPhoneNumber(string s)
        {
            PhoneNumber ph = new PhoneNumber();
            ph.CountryCode = s[0].ToString();
            ph.AreaCode = s.Substring(2, 3);
            ph.Phone = s.Substring(6, 7);
            ph.Extension = "";
            return ph;
        }
    }
}
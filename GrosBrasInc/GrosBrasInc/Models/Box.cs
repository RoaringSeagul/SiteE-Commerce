using GrosBrasInc.EstimatingProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Module.Models
{
    public class Box
    {
        public BoxType BoxType { get; set; }
        public double WeightLb { get; set; }
        public Dimension Length { get { return BoxTypeToDimensions(1); } }
        public Dimension Width { get { return BoxTypeToDimensions(2); } }
        public Dimension Height { get { return BoxTypeToDimensions(3); } }

        internal Dimension BoxTypeToDimensions(byte b)
        {
            Dimension d = new Dimension();
            switch (b)
            {
                case 1:
                    switch (BoxType)
                    {
                        case BoxType.SmallEnveloppe:
                            d.Value = 12.00m;
                            break;
                        case BoxType.BigEnveloppe:
                            d.Value = 20.00m;
                            break;
                        case BoxType.TinyBox:
                            d.Value = 5.00m;
                            break;
                        case BoxType.SmallBox:
                            d.Value = 12.00m;
                            break;
                        case BoxType.MediumBox:
                            d.Value = 25.00m;
                            break;
                        case BoxType.BigBox:
                            d.Value = 35.00m;
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (BoxType)
                    {
                        case BoxType.SmallEnveloppe:
                            d.Value = 5.00m;
                            break;
                        case BoxType.BigEnveloppe:
                            d.Value = 10.00m;
                            break;
                        case BoxType.TinyBox:
                            d.Value = 5.00m;
                            break;
                        case BoxType.SmallBox:
                            d.Value = 12.00m;
                            break;
                        case BoxType.MediumBox:
                            d.Value = 25.00m;
                            break;
                        case BoxType.BigBox:
                            d.Value = 35.00m;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (BoxType)
                    {
                        case BoxType.SmallEnveloppe:
                            d.Value = 0.20m;
                            break;
                        case BoxType.BigEnveloppe:
                            d.Value = 0.60m;
                            break;
                        case BoxType.TinyBox:
                            d.Value = 5.00m;
                            break;
                        case BoxType.SmallBox:
                            d.Value = 12.00m;
                            break;
                        case BoxType.MediumBox:
                            d.Value = 25.00m;
                            break;
                        case BoxType.BigBox:
                            d.Value = 35.00m;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            d.DimensionUnit = DimensionUnit.@in;
            return d;
        }
    }
}
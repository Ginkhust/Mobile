using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using Parse;
using System.ComponentModel.DataAnnotations;

namespace AdminControl.Models
{
    public class ProductViewModel
    {
        public string productId { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public string manufacture { get; set; }
        public float salePrice { get; set; }
        public float oldPrice { get; set; }
        public string thumbnailImage { get; set; }
        public IList<string> smallSlideImage { get; set; }
        public IList<string> largeSlideImage { get; set; }

        public Specification specification;

        public void setSpecification(Specification spec)
        {
            specification = new Specification();
            specification.specificationId = spec.specificationId;
            specification.screen = spec.screen;
            specification.frontCamera = spec.frontCamera;
            specification.backCamera = spec.backCamera;
            specification.os = spec.os;
            specification.chipset = spec.chipset;
            specification.cpu = spec.cpu;
            specification.ram = spec.ram;
            specification.internalStorage = spec.internalStorage;
            specification.sdcard = spec.sdcard;
            specification.simNumber = spec.simNumber;
            specification.batery = spec.batery;
            specification.connection = spec.connection;
        }

        public Specification getSpecification()
        {
            return specification;
        }

        public ProductViewModel() { }

        public ProductViewModel(ParseObject po)
        {

            productId = po.ObjectId;
            name = po.Get<string>("name");
            price = po.Get<float>("price");
            quantity = po.Get<int>("quantity");
            manufacture = po.Get<string>("manufacture");
            salePrice = po.Get<float>("salePrice");
            oldPrice = po.Get<float>("oldPrice");
            thumbnailImage = po.Get<string>("thumbnailImage");
            smallSlideImage = po.Get<IList<string>>("smallSlideImage");
            largeSlideImage = po.Get<IList<string>>("largeSlideImage");
        }
    }

    public class Specification
    {
        public Specification() { }

        public Specification(ParseObject specification)
        {
            specificationId = specification.ObjectId;
            screen = specification.Get<string>("screen");
            frontCamera = specification.Get<string>("frontCamera");
            backCamera = specification.Get<string>("backCamera");
            os = specification.Get<string>("os");
            chipset = specification.Get<string>("chipset");
            cpu = specification.Get<string>("cpu");
            ram = specification.Get<string>("ram");
            internalStorage = specification.Get<string>("internalStorage");
            sdcard = specification.Get<string>("sdcard");
            simNumber = specification.Get<string>("simNumber");
            batery = specification.Get<string>("batery");
            connection = specification.Get<string>("connection");

        }

        public string specificationId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string screen { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string frontCamera { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string backCamera { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string os { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string chipset { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string cpu { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string ram { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string internalStorage { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string sdcard { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string simNumber { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string batery { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string connection { get; set; }
    }
}
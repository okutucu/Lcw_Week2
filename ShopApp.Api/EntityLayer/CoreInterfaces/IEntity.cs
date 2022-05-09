using System;
using ShopApp.Api.EntityLayer.Enums;

namespace ShopApp.Api.EntityLayer.CoreInterfaces
{
    public interface IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DataStatus Status { get; set; }

    }
}

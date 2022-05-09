using System;
using ShopApp.Api.EntityLayer.CoreInterfaces;
using ShopApp.Api.EntityLayer.Enums;

namespace ShopApp.Api.EntityLayer.Models
{
    public class BaseEntity : IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DataStatus Status { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
    }
}

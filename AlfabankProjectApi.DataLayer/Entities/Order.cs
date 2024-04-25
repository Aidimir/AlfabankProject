using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfabankProjectApi.DataLayer.Entities;
public class Order
{
    [Key]
    [DisplayName("id")]
    public Guid Id { get; set; }
    //Придумать как хранить лист Id и парсить их в лист MenuItem
    //на подобие внешнего ключа и виртуального поля Restaurant
    public List<Guid> MenuItems { get; set; }
    [DisplayName("orderSum")]
    public double OrderSum { get; set; }
    [DisplayName("restaurant")]
    [ForeignKey("restaurants")]
    public Guid RestaurantId { get; set; }
    public virtual Restaurant Restaurant { get; set; }
    [DisplayName("client")]
    public Guid Client {  get; set; }
    [DisplayName("expiresAt")]
    public TimeOnly ExpiresAt { get; set; }
}

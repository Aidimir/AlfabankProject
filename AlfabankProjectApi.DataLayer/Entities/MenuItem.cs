using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfabankProjectApi.DataLayer.Entities;
public class MenuItem
{
    [Key]
    [DisplayName("id")]
    public Guid Id { get; set; }
    [DisplayName("title")]
    public string Title { get; set; }
    [DisplayName("compoundDescription")]
    public string? CompoundDescription { get; set; }
    [DisplayName("price")]
    public double Price { get; set; }
    [DisplayName("restaurant")]
    //[Index]
    public Guid Restaurant { get; set; }
}

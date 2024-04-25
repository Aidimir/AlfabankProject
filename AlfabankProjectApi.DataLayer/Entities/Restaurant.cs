using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfabankProjectApi.DataLayer.Entities;
public class Restaurant
{
    [Key]
    [DisplayName("id")]
    public Guid Id { get; set; }
    [DisplayName("title")]
    public string Title { get; set; }
    [DisplayName("shortTitle")]
    public string? ShortTitle { get; set; }
    [DisplayName("rating")]
    public double? Rating { get; set; }
}
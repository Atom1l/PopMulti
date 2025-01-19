using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PopMulti.Models.PopModel
{
    public class PopMultiModel
    {
        [Key]
        public int Id { get; set; }
        public int KMUTT { get; set; }
        public int SU {  get; set; }
        public int SWU { get; set; }
    }
}

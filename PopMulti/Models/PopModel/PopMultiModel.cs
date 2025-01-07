using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PopMulti.Models.PopModel
{
    public class PopMultiModel
    {
        public int Id { get; set; }
        public int KMUTT { get; set; }
        public int SU {  get; set; }
        public int SWU { get; set; }
    }
}

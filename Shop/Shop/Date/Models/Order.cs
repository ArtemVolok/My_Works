using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//необходимые поля для формочки в заказе
namespace Shop.Date.Models
{

    public class Order
    {
        [BindNever]//не показывать
        public int id { get; set; } //это для б.д

        [Display(Name ="Введите имя")]
        [StringLength(25)]//если меньше 20 символов то не проходит
        [Required(ErrorMessage ="Длина имени не менее 5 символов")]
        public string name { get; set; }//всё остальное для формы

        [Display(Name = "Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Длина адреса не менее 15 символов")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина номера не менее 10 цифр")]
        public string phone { get; set; }

        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина email не менее 15 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]//чтобы вообще не отображалось в исходном коде
        public DateTime orderTime { get; set; }  //время заказа
        public List<OrderDetail> orderDetails { get; set; } //описывает те товары, которые преобретают(их описание)
    }
}

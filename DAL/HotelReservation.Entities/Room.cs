using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class Room : MainEntity
    {
        [Required]
        public int PersonNumbers { get; set; }
        [Required]
        public decimal Price { get; set; }

        public RoomType? RoomType { get; set; }

        /// <summary>
        /// Info w stylu pierdoly (telewizor, lazienka itd.)
        /// opis jest przechowywany w JSON (bez sensu rozbijac na oddzielne kolumny)
        /// </summary>
        [MaxLength(10000)]
        public string AdditionalInfo { get; set; }

        [Required]
        public virtual Hotel Hotel { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

    }
    public enum RoomType
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown = 0,

        Standard = 1,

        Deluxe = 2
    }
}

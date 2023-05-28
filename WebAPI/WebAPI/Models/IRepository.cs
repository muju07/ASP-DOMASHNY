﻿namespace WebApi.Models
{
    public interface IRepository
    {
        IEnumerable<Reservation> Reservations { get; }
        Reservation this[int Id] { get; }
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        void DeleteReservation(int Id); //интерфейс способен отлавливать ошибки на уровне системы
    }
}

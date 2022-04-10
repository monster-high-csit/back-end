﻿using Cinema.Entities;

namespace Cinema.IServices
{
    public interface IFilmService
    {
        Film GetBook(int id);
        int DeleteFilm(int id);
    }
}

﻿using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Data;

public static class DbInitializer
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        var authors = new Author[]
        {
            new Author
            {
                Id = 1,
                FirstName = "Джоан",
                LastName = "Роулинг"
            },
            new Author
            {
                Id = 2,
                FirstName = "Анджей",
                LastName = "Сапковский"
            },
            new Author
            {
                Id = 3,
                FirstName = "Стивен",
                LastName = "Кинг"
            },
            new Author
            {
                Id = 4,
                FirstName = "Маргарет",
                LastName = "Митчелл"
            },
            new Author
            {
                Id = 5,
                FirstName = "Дэн",
                LastName = "Браун"
            }
        };

        var genres = new Genre[]
        {
            new Genre
            {
                Id = 1,
                Name = "Фэнтези",
                Description = "Фэнтези — это фантастический жанр, который использует мифологические и фольклорные," +
                " а также сказочные мотивы в повествовании. В фэнтези часто создаются вымышленные миры, населенные" +
                " необычными существами и героями, обладающими магическими способностями. Фэнтези может быть основано" +
                " на разных мифологиях и культурах, а также иметь разные поджанры, такие как эпическое фэнтези," +
                " героическое фэнтези, городское фэнтези и т.д."
            },
            new Genre
            {
                Id = 2,
                Name = "Детектив",
                Description = "Детектив — это жанр литературы, в котором главным элементом является расследование" +
                " преступления, загадки или тайны. В детективе обычно присутствуют следующие персонажи: детектив," +
                " который пытается разгадать преступление, подозреваемый, который может быть виновным или невиновным," +
                " жертва, которая пострадала от преступления, и свидетели, которые могут дать полезную информацию." +
                " Детектив может иметь разные поджанры, такие как классический детектив, иронический детектив," +
                " полицейский детектив и т.д."
            },
            new Genre
            {
                Id = 3,
                Name = "Исторический роман",
                Description = "Исторический роман — это жанр литературы," +
                " в котором действие происходит в определенный исторический период или эпоху." +
                " В историческом романе автор стремится воссоздать атмосферу и детали того времени," +
                " а также показать взаимодействие вымышленных и реальных исторических персонажей." +
                " Исторический роман может быть основан на реальных событиях или выдуманных," +
                " а также иметь разные поджанры, такие как приключенческий исторический роман," +
                " военный исторический роман, романтический исторический роман и т.д."
            }
        };

        var books = new Book[]
        {
            new Book
            {
                Id = 1,
                Isbn = "978-5-389-17021-6",
                Title = "Гарри Поттер и узник Азкабана",
                GenreId = 1,
                AuthorId = 1,
                Description = "Третья книга из серии о приключениях юного волшебника Гарри Поттера," +
                " который узнает что их тюрьмы сбежал опасный преступник Сириус Блэк, якобы замышляющий убить Гарри"
            },
            new Book
            {
                Id = 2,
                Isbn = "978-5-17-120969-2",
                Title = "Последнее желание",
                GenreId = 1,
                AuthorId = 2,
                Description = "Первая книга из цикла «Ведьмак» о приключениях профессионального охотника" +
                " за чудовищами Геральта из Ривии, который путешествует по миру, полному магии и опасностей," +
                " и выполняет различные заказы"
            },
            new Book
            {
                Id = 3,
                Isbn = "978-5-17-085348-9",
                Title = "Зеленая миля",
                GenreId = 2,
                AuthorId = 3,
                Description = "Роман, действие которого происходит в тюремном блоке смертников," +
                " где надзиратель Пол Эджкомб сталкивается с необычным заключенным Джоном Коффи," +
                " обладающим сверхъестественными способностями"
            },
            new Book
            {
                Id = 4,
                Isbn = "978-5-389-17583-9",
                Title = "Унесенные ветром",
                GenreId = 3,
                AuthorId = 4,
                Description = "Эпическая история любви и ненависти, страсти и гордости," +
                " жизни и смерти на фоне Гражданской войны в США, в центре которой находится" +
                " красавица и своенравная Скарлетт О’Хара и ее отношения с харизматичным Реттом Батлером"
            },
            new Book
            {
                Id = 5,
                Isbn = "978-5-17-121367-5",
                Title = "Код да Винчи",
                GenreId = 2,
                AuthorId = 5,
                Description = "Знаменитый роман о тайне, которая скрывается в произведениях Леонардо да Винчи," +
                " и о загадочном ордене, который охраняет ее. Главные герои - профессор символогии Роберт Лэнгдон" +
                " и криптограф Софи Невё - пытаются разгадать код, который может изменить мировую историю"
            }
        };

        modelBuilder.Entity<Author>().HasData(authors);
        modelBuilder.Entity<Genre>().HasData(genres);
        modelBuilder.Entity<Book>().HasData(books);
    }
}

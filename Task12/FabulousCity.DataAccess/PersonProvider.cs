﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FabulousCity.DataAccess {
    public class PersonProvider {
        public Person[] GetPersons(int idFrom, int count) {
            Person[] result = GetPersonsInternal(idFrom, count);

            int timeout = GetTimeout(idFrom, count);

            Debug.WriteLine($"{nameof(GetPersons)}: requested persons from {idFrom} to {idFrom + count} ({count}).Timeout is {timeout} ms");

            Thread.Sleep(timeout);

            return result;
        }

        public async Task<Person[]> GetPersonsAsync(int idFrom, int count) {
            Person[] result = GetPersonsInternal(idFrom, count);

            int timeout = GetTimeout(idFrom, count);

            Debug.WriteLine($"{nameof(GetPersonsAsync)}: requested persons from {idFrom} to {idFrom + count} ({count}).Timeout is {timeout} ms");

            await Task.Delay(timeout);

            return result;
        }

        public Person[] GetAll() {
            return GetPersons(1, PersonCount);
        }

        private Person[] GetPersonsInternal(int idFrom, int count) {
            if (idFrom <= 0 || count <= 0 || idFrom > PersonCount) return new Person[0];
            if (idFrom + count - 1 > PersonCount) count = PersonCount - idFrom + 1;
            Person[] result = new Person[count];
            for (int i = 0; i < count; i++) {
                result[i] = new Person {
                    Id = i + idFrom,
                    Age = _random.Next(101),
                    Name = Names[_random.Next(Names.Length)],
                    PassportNo = _random.Next(1000000),
                    PassportSeries = _random.Next(10000)
                };
            }

            return result;
        }

        private static int GetTimeout(int idFrom, int count) {
            int lineSlowFactor;
            int mln = idFrom / 1_000_000;
            if (mln == 0) lineSlowFactor = 1;
            else if (mln == 1) lineSlowFactor = 4;
            else if (mln <= 3) lineSlowFactor = 2;
            else if (mln <= 5) lineSlowFactor = 0;
            else if (mln <= 7) lineSlowFactor = 6;
            else if (mln <= 8) lineSlowFactor = 10;
            else if (mln <= 11) lineSlowFactor = 1;
            else lineSlowFactor = 5;

            int countSlowFactor = count / 1000;

            return lineSlowFactor * countSlowFactor + Latency;
        }

        private const int PersonCount = 12_345_678;
        private const int Latency = 1;
        private readonly Random _random = new();
        private static readonly string[] Names =
        {
            "Ярослава",
            "Янита",
            "Яна",
            "Ядвига",
            "Юстина",
            "Юнона",
            "Юна",
            "Юлия",
            "Юлиана",
            "Юзефа",
            "Юдита",
            "Эстер",
            "Эсмеральда",
            "Эрнестина",
            "Эрика",
            "Эмма",
            "Эмилия",
            "Эльмира",
            "Эльза",
            "Эльга",
            "Эльвира",
            "Элоиза",
            "Эллада",
            "Элла",
            "Элина",
            "Элиза",
            "Элеонора",
            "Эдита",
            "Эдда",
            "Эвелина",
            "Чеслава",
            "Цецилия",
            "Цветана",
            "Христя",
            "Христина",
            "Хильда",
            "Фрида",
            "Фредерика",
            "Француаза",
            "Флора",
            "Филиппина",
            "Феодора",
            "Фелиция",
            "Фекла",
            "Фая",
            "Фарида",
            "Фаня",
            "Фаина",
            "Фаиза",
            "Устина",
            "Ульяна",
            "Томила",
            "Тереза",
            "Татьяна",
            "Тамара",
            "Тала",
            "Таисия",
            "Таира",
            "Сусанна",
            "Стефания",
            "Стелла",
            "Станислава",
            "Софья",
            "Снежана",
            "Симона",
            "Сима",
            "Сильвия",
            "Серафима",
            "Северина",
            "Светлана",
            "Сара",
            "Санта",
            "Саломея",
            "Сабина",
            "Руфина",
            "Руслана",
            "Ростислава",
            "Роксана",
            "Роза",
            "Роберта",
            "Римма",
            "Рената",
            "Рема",
            "Регина",
            "Ревекка",
            "Рахиль",
            "Раиса",
            "Радосвета",
            "Рада",
            "Прасковья",
            "Полина",
            "Пелагея",
            "Патриция",
            "Памела",
            "Павла",
            "Ольга",
            "Олеся",
            "Оксана",
            "Одетта",
            "Нора",
            "Нонна",
            "Нина",
            "Нила",
            "Ника",
            "Нелли",
            "Нателла",
            "Наталья",
            "Нана",
            "Надежда",
            "Муза",
            "Моника",
            "Михайлина",
            "Мирра",
            "Мирослава",
            "Милана",
            "Мелания",
            "Матильда",
            "Марта",
            "Марселина",
            "Мария",
            "Марина",
            "Марианна",
            "Маргарита",
            "Мальвина",
            "Майя",
            "Магдалина",
            "Людмила",
            "Любовь",
            "Луиза",
            "Лолита",
            "Лия",
            "Линда",
            "Лилия",
            "Лидия",
            "Лиана",
            "Леся",
            "Леонтина",
            "Леонида",
            "Леокадия",
            "Лейла",
            "Лаура",
            "Лариса",
            "Лада",
            "Ксения",
            "Кристина",
            "Кора",
            "Констанция",
            "Климентина",
            "Клена",
            "Клариса",
            "Клара",
            "Клавдия",
            "Кира",
            "Каролина",
            "Карина",
            "Капитолина",
            "Камилла",
            "Ия",
            "Ирэна",
            "Ирма",
            "Ирина",
            "Ираида",
            "Иоланта",
            "Инна",
            "Инесса",
            "Инга",
            "Инара",
            "Илона",
            "Изольда",
            "Изабелла",
            "Ивона",
            "Иветта",
            "Иванна",
            "Зоя",
            "Злата",
            "Зинаида",
            "Земфира",
            "Зара",
            "Жозефина",
            "Жанна",
            "Ефросинья",
            "Елизавета",
            "Елена",
            "Екатерина",
            "Евдокия",
            "Евгения",
            "Ева",
            "Доминика",
            "Доля",
            "Дионисия",
            "Диодора",
            "Динара",
            "Дина",
            "Диана",
            "Джульетта",
            "Джулия",
            "Джемма",
            "Дебора",
            "Дарья",
            "Дарина",
            "Данута",
            "Даниэла",
            "Дана",
            "Дайна",
            "Гюзель",
            "Грета",
            "Гражина",
            "Глория",
            "Глафира",
            "Гизелла",
            "Гертруда",
            "Георгина",
            "Генриетта",
            "Гелла",
            "Гелена",
            "Гаянэ",
            "Галина",
            "Габриэлла",
            "Владлена",
            "Владислава",
            "Виталина",
            "Вирджиния",
            "Виолетта",
            "Вилора",
            "Виктория",
            "Вида",
            "Вета",
            "Веста",
            "Веселина",
            "Вероника",
            "Вера",
            "Венера",
            "Василиса",
            "Варвара",
            "Ванда",
            "Валерия",
            "Валентина",
            "Бронислава",
            "Борислава",
            "Божена",
            "Богдана",
            "Бирута",
            "Биргит",
            "Берта",
            "Береслава",
            "Бенедикта",
            "Белла",
            "Беатриса",
            "Беата",
            "Аурелия",
            "Ася",
            "Астра",
            "Архелия",
            "Арина",
            "Ариадна",
            "Анэля",
            "Анфиса",
            "Антонина",
            "Анна",
            "Анита",
            "Анисья",
            "Анжелика",
            "Анжела",
            "Ангелина",
            "Анастасия",
            "Амина",
            "Амалия",
            "Альбина",
            "Альберта",
            "Алла",
            "Алиса",
            "Алина",
            "Алико",
            "Александра",
            "Алевтина",
            "Алана",
            "Акулина",
            "Аида",
            "Азиза",
            "Аза",
            "Адриана",
            "Адель",
            "Ада",
            "Агния",
            "Агнесса",
            "Агафья",
            "Агата",
            "Аврора",
            "Августа",
            "Абрам",
            "Ясон",
            "Ярослав",
            "Яромир",
            "Ян",
            "Яков",
            "Яким",
            "Юхим",
            "Юрий",
            "Юлиан",
            "Юджин",
            "Эрнест",
            "Эрик",
            "Эраст",
            "Эммануил",
            "Эмиль",
            "Эльдар",
            "Эдуард",
            "Эдгар",
            "Эдвард",
            "Чеслав",
            "Цезарь",
            "Христофор",
            "Христос",
            "Христиан",
            "Харитон",
            "Фридрих",
            "Франц",
            "Фома",
            "Флорентий",
            "Филипп",
            "Филимон",
            "Фидель",
            "Феофан",
            "Феодосий",
            "Феликс",
            "Федот",
            "Федор",
            "Устин",
            "Ульян",
            "Ульманас",
            "Трофим",
            "Трифон",
            "Тихон",
            "Тит",
            "Тимур",
            "Тимофей",
            "Тигрий",
            "Тигран",
            "Тибор",
            "Терентий",
            "Теодор",
            "Тарас",
            "Тамаз",
            "Талик",
            "Таис",
            "Степан",
            "Станислав",
            "Стакрат",
            "Спиридон",
            "Спартак",
            "Соломон",
            "Сократ",
            "Симон",
            "Сергей",
            "Серафим",
            "Семен",
            "Севастьян",
            "Святослав",
            "Самуил",
            "Савелий",
            "Савва",
            "Рустам",
            "Руслан",
            "Рудольф",
            "Рубен",
            "Ростислав",
            "Роман",
            "Ролан",
            "Родион",
            "Роберт",
            "Ричард",
            "Рифат",
            "Ренольд",
            "Ренат",
            "Рем",
            "Реймонд",
            "Рашид",
            "Рафик",
            "Рафаил",
            "Ратмир",
            "Раис",
            "Радомир",
            "Радий",
            "Равиль",
            "Прохор",
            "Потап",
            "Порфирий",
            "Платон",
            "Петр",
            "Парамон",
            "Павел",
            "Оскар",
            "Осип",
            "Орест",
            "Онисим",
            "Олесь",
            "Олег",
            "Олан",
            "Овидий",
            "Никон",
            "Николай",
            "Никифор",
            "Никита",
            "Никанор",
            "Наум",
            "Натан",
            "Назарий",
            "Назар",
            "Муслим",
            "Мурат",
            "Мстислав",
            "Моисей",
            "Модест",
            "Мичлов",
            "Михаил",
            "Митрофан",
            "Мирослав",
            "Мирон",
            "Милан",
            "Мечислав",
            "Мефодий",
            "Мераб",
            "Матвей",
            "Мартин",
            "Марк",
            "Мариан",
            "Марат",
            "Мануил",
            "Максимилиан",
            "Максим",
            "Макар",
            "Май",
            "Мадлен",
            "Людвиг",
            "Любомир",
            "Лукьян",
            "Леопольд",
            "Леонтий",
            "Леонид",
            "Леонард",
            "Леван",
            "Лев",
            "Лазарь",
            "Лаврентий",
            "Кузьма",
            "Кристиан",
            "Константин",
            "Кондрат",
            "Клод",
            "Клим",
            "Клавдий",
            "Кирилл",
            "Ким",
            "Карл",
            "Карен",
            "Казимир",
            "Исай",
            "Исаакий",
            "Ираклий",
            "Ипполит",
            "Иосиф",
            "Ионос",
            "Иннокентий",
            "Илья",
            "Иларион",
            "Измаил",
            "Игорь",
            "Игнатий",
            "Игнат",
            "Иван",
            "Ибрагим",
            "Зиновий",
            "Зигмунд",
            "Захария",
            "Захар",
            "Жорж",
            "Ждан",
            "Жан",
            "Ефрем",
            "Ефим",
            "Ерофей",
            "Ермолай",
            "Емельян",
            "Елисей",
            "Елизар",
            "Егор",
            "Евдоким",
            "Евграф",
            "Евгений",
            "Дорофей",
            "Дмитрий",
            "Денис",
            "Демьян",
            "Демид",
            "Даниил",
            "Дамир",
            "Давид",
            "Гурий",
            "Григорий",
            "Градимир",
            "Гордон",
            "Гордей",
            "Глеб",
            "Герман",
            "Герасим",
            "Геральд",
            "Георгий",
            "Генрих",
            "Геннадий",
            "Галактион",
            "Гавриил",
            "Вячеслав",
            "Всеволод",
            "Вольдемар",
            "Володар",
            "Владлен",
            "Владислав",
            "Владимир",
            "Виталий",
            "Вильгельм",
            "Вилен",
            "Виктор",
            "Викентий",
            "Вениамин",
            "Венедикт",
            "Василий",
            "Вальтер",
            "Валерий",
            "Валентин",
            "Вадим",
            "Бронислав",
            "Борис",
            "Бонифаций",
            "Болеслав",
            "Богдан",
            "Бертран",
            "Бернард",
            "Бенедикт",
            "Ашот",
            "Ахмет",
            "Афанасий",
            "Аскольд",
            "Архип",
            "Артур",
            "Артемий",
            "Артем",
            "Арслан",
            "Арсений",
            "Арон",
            "Арнольд",
            "Аркадий",
            "Аристарх",
            "Антон",
            "Андрей",
            "Ангел",
            "Анатолий",
            "Амаяк",
            "Альфред",
            "Альберт",
            "Алексей",
            "Александр",
            "Адриан",
            "Адольф",
            "Адам",
            "Авдей",
            "Август",
            "Аваз"
        };
    }
}
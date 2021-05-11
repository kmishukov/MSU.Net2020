namespace FabulousCity.DataAccess
{
    public record Person
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Age { get; init; }
        public int PassportSeries { get; init; }
        public int PassportNo { get; init; }

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Age = {Age}, Passport = {PassportSeries} {PassportNo:D6}";
        }
    }
}
using Examich.Entity.Seed.Seeder;

namespace Examich.Entity.Seed
{
    public class Seed
    {
        private ExamichDbContext _context;

        public Seed(ExamichDbContext context)
        {
            _context = context;
        }
        
        public async void Init()
        {
            _context.Database.EnsureCreated();

            // SEED HERE
            UserSeeder.Seed(_context);
            ExamSeeder.Seed(_context);
        }
    }
}
using ExamichService.Entity.Seed.Seeder;

namespace ExamichService.Entity.Seed
{
    public class Seed
    {
        private ExamichServiceDbContext _context;

        public Seed(ExamichServiceDbContext context)
        {
            _context = context;
        }
        
        public void Init()
        {
            _context.Database.EnsureCreated();

            // SEED HERE
            ExamSeeder.Seed(_context);
        }
    }
}
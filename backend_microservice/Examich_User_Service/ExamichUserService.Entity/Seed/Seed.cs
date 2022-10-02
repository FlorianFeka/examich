using ExamichUserService.Entity.Seed.Seeder;

namespace ExamichUserService.Entity.Seed
{
    public class Seed
    {
        private ExamichUserServiceDbContext _context;

        public Seed(ExamichUserServiceDbContext context)
        {
            _context = context;
        }
        
        public void Init()
        {
            _context.Database.EnsureCreated();

            // SEED HERE
            UserSeeder.Seed(_context);
        }
    }
}
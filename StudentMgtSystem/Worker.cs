using Services.Interface;

namespace StudentMgtSystem
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public Worker(ILogger<Worker> logger, IStudentRepository studentRepository, IEmailService emailService)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            var students = await _studentRepository.GetAllStudents();
            if (students is null)
            {
                _logger.LogInformation("student is null");
            }
            foreach (var item in students)
                {
                try
                {
                    _logger.LogInformation($"{item.Email}");
                    await _emailService.SendEmail("noreply@globusbank.com", item);


                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
                }                
                
                await Task.Delay(20000, stoppingToken);
            }
        }
    }


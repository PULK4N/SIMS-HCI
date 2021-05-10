using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Map
{

    #region controllers
    public static AnamnesisController AnamnesisController { get; set; }
    public static AppointmentController AppointmentController { get; set; }
    public static DoctorController DoctorController { get; set; }
    public static GuestPatientController GuestPatientController { get; set; }
    public static MedicalRecordController MedicalRecordController { get; set; }
    public static DrugController DrugController { get; set; }
    public static PatientController PatientController { get; set; }
    public static PrescriptionController PrescriptionController { get; set; }
    public static RoomController RoomController { get; set; }
    public static ReviewController ReviewController { get; set; }

    #endregion

    #region services

    public static IAnamnesisService AnamnesisService { get; set; }
    public static IAppointmentService AppointmentService { get; set; }
    public static IDoctorService DoctorService { get; set; }
    public static IGuestPatientService GuestPatientService { get; set; }
    public static IMedicalRecordService MedicalRecordService { get; set; }
    public static IDrugService DrugService { get; set; }
    public static IPatientService PatientService { get; set; }
    public static IPrescriptionService PrescriptionService { get; set; }
    public static IRoomService RoomService { get; set; }
    public static IReviewService ReviewService { get; set; }

    #endregion

    #region Repositories

    public static IAnamnesisRepository AnamnesisRepository { get; set; }
    public static IAppointmentRepository AppointmentRepository { get; set; }
    public static IDoctorRepository DoctorRepository { get; set; }
    public static IGuestPatientRepository GuestPatientRepository { get; set; }
    public static IMedicalRecordRepository MedicalRecordRepository { get; set; }
    public static IDrugRepository DrugRepository { get; set; }
    public static IPatientRepository PatientRepository { get; set; }
    public static IPrescriptionRepository PrescriptionRepository { get; set; }
    public static IRoomRepository RoomRepository { get; set; }
    public static IReviewRepository ReviewRepository { get; set; }

    #endregion
    public static void Instantiate()
    {
        AnamnesisRepository = new AnamnesisContextDB();
        AppointmentRepository = new AppointmentContextDB();
        DoctorRepository = new DoctorContextDB();
        GuestPatientRepository = new GuestPatientContextDB();
        MedicalRecordRepository = new MedicalRecordContextDB();
        DrugRepository = new DrugRepository();
        PatientRepository = new PatientContextDB();
        PrescriptionRepository = new PrescriptionContextDB();
        RoomRepository = new RoomContextDB();
        ReviewRepository = new ReviewContextDB();

        AnamnesisService = new AnamnesisService(AnamnesisRepository);
        AppointmentService = new AppointmentService(AppointmentRepository);
        DoctorService = new DoctorService(DoctorRepository);
        GuestPatientService = new GuestPatientService(GuestPatientRepository);
        MedicalRecordService = new MedicalRecordService(MedicalRecordRepository);
        DrugService = new DrugService(DrugRepository);
        PatientService = new PatientService(PatientRepository);
        PrescriptionService = new PrescriptionService(PrescriptionRepository);
        RoomService = new RoomService(RoomRepository);
        ReviewService = new ReviewService(ReviewRepository);

        AnamnesisController = new AnamnesisController(AnamnesisService);
        AppointmentController = new AppointmentController(AppointmentService);
        DoctorController = new DoctorController(DoctorService);
        GuestPatientController = new GuestPatientController(GuestPatientService);
        MedicalRecordController = new MedicalRecordController(MedicalRecordService);
        DrugController = new DrugController(DrugService);
        PatientController = new PatientController(PatientService);
        PrescriptionController = new PrescriptionController(PrescriptionService);
        RoomController = new RoomController(RoomService);
        ReviewController = new ReviewController(ReviewService);
    }

}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ControllerMapper
{
    private static ControllerMapper instance = null;
    public static ControllerMapper Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ControllerMapper();
            }
            return instance;
        }
    }

    public AnamnesisController AnamnesisController { get; set; }
    public AppointmentController AppointmentController { get; set; }
    public DoctorController DoctorController { get; set; }
    public GuestPatientController GuestPatientController { get; set; }
    public MedicalRecordController MedicalRecordController { get; set; }
    public DrugController DrugController { get; set; }
    public PatientController PatientController { get; set; }
    public PrescriptionController PrescriptionController { get; set; }
    public RoomController RoomController { get; set; }
    public StaticInventoryController StaticInventoryController { get; set; }

    private ControllerMapper() {
        this.AnamnesisController = new AnamnesisController(new AnamnesisService(new AnamnesisContextDB()));
        this.AppointmentController = new AppointmentController(new AppointmentService(new AppointmentContextDB()));
        this.DoctorController = new DoctorController(new DoctorService(new DoctorContextDB()));
        this.GuestPatientController = new GuestPatientController(new GuestPatientService(new GuestPatientContextDB()));
        this.MedicalRecordController = new MedicalRecordController(new MedicalRecordService(new MedicalRecordContextDB()));
        this.DrugController = new DrugController(new DrugService(new DrugRepository()));
        this.PatientController = new PatientController(new PatientService(new PatientContextDB()));
        this.PrescriptionController = new PrescriptionController(new PrescriptionService(new PrescriptionContextDB()));
        this.RoomController = new RoomController(new RoomService(new RoomContextDB()));
        this.StaticInventoryController = new StaticInventoryController(new StaticInventoryService(new StaticInventoryContextDB()));
    }

}




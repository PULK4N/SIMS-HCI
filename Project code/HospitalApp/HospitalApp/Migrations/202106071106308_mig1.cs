namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allergies",
                c => new
                    {
                        AllergiesId = c.Long(nullable: false, identity: true),
                        AllergieType = c.String(),
                    })
                .PrimaryKey(t => t.AllergiesId);
            
            CreateTable(
                "dbo.Anamnesis",
                c => new
                    {
                        AnamnesisId = c.Long(nullable: false, identity: true),
                        TimeOf = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AnamnesisId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        PrescriptionId = c.Long(nullable: false, identity: true),
                        Dosage = c.Int(nullable: false),
                        Usage = c.String(),
                        Period = c.String(),
                        Date = c.DateTime(nullable: false),
                        HandoutDate = c.DateTime(nullable: false),
                        Doctor_DoctorId = c.Long(),
                        Drug_DrugId = c.Long(),
                        Anamnesis_AnamnesisId = c.Long(),
                    })
                .PrimaryKey(t => t.PrescriptionId)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorId)
                .ForeignKey("dbo.Drugs", t => t.Drug_DrugId)
                .ForeignKey("dbo.Anamnesis", t => t.Anamnesis_AnamnesisId)
                .Index(t => t.Doctor_DoctorId)
                .Index(t => t.Drug_DrugId)
                .Index(t => t.Anamnesis_AnamnesisId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Long(nullable: false, identity: true),
                        AboutMe = c.String(),
                        Specialization = c.Int(nullable: false),
                        Employee_EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Long(nullable: false, identity: true),
                        Beginning = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        AppointmentType = c.Int(nullable: false),
                        AppointmentStatus = c.Int(nullable: false),
                        Doctor_DoctorId = c.Long(),
                        Patient_PatientId = c.Long(),
                        Room_RoomId = c.Long(),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .Index(t => t.Doctor_DoctorId)
                .Index(t => t.Patient_PatientId)
                .Index(t => t.Room_RoomId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Long(nullable: false, identity: true),
                        SchedulingAttempts = c.Int(nullable: false),
                        alergies = c.String(),
                        MedicalRecord_MedicalRecordId = c.Long(),
                        User_UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecord_MedicalRecordId)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.MedicalRecord_MedicalRecordId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        MedicalRecordId = c.Long(nullable: false, identity: true),
                        LastMesuredHeight = c.Single(nullable: false),
                        LastMesuredWeight = c.Single(nullable: false),
                        Anamnesis_AnamnesisId = c.Long(),
                    })
                .PrimaryKey(t => t.MedicalRecordId)
                .ForeignKey("dbo.Anamnesis", t => t.Anamnesis_AnamnesisId)
                .Index(t => t.Anamnesis_AnamnesisId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Jmbg = c.Long(nullable: false),
                        EMail = c.String(nullable: false, maxLength: 50),
                        Sex = c.Int(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        RegisteredUser_Username = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUser_Username, cascadeDelete: true)
                .Index(t => t.RegisteredUser_Username);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Long(nullable: false, identity: true),
                        Information = c.String(maxLength: 1000),
                        User_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        RoomType = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        Salary = c.Single(nullable: false),
                        BeginWorkingHours = c.DateTime(nullable: false),
                        EndWorkingHours = c.DateTime(nullable: false),
                        AnnualLeave = c.Int(nullable: false),
                        SickLeave = c.Int(nullable: false),
                        User_UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        DrugId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                        DrugStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrugId);
            
            CreateTable(
                "dbo.Beds",
                c => new
                    {
                        BedId = c.Long(nullable: false, identity: true),
                        RoomId = c.Long(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BedId);
            
            CreateTable(
                "dbo.DoctorsReferrals",
                c => new
                    {
                        DoctorReferralId = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.DoctorReferralId);
            
            CreateTable(
                "dbo.GuestPatients",
                c => new
                    {
                        GuestPatientId = c.Int(nullable: false, identity: true),
                        ArrivalDate = c.DateTime(nullable: false),
                        EmergencyInfo = c.String(),
                        Appointment_AppointmentId = c.Long(nullable: false),
                        User_UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.GuestPatientId)
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Appointment_AppointmentId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.HospitalClinics",
                c => new
                    {
                        HospitalClinicId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HospitalClinicId);
            
            CreateTable(
                "dbo.HospitalTreatments",
                c => new
                    {
                        TreatmentId = c.Long(nullable: false, identity: true),
                        Beginning = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        HospitalTreatmentStatus = c.Int(nullable: false),
                        Bed_BedId = c.Long(),
                        Patient_PatientId = c.Long(),
                        Room_RoomId = c.Long(),
                    })
                .PrimaryKey(t => t.TreatmentId)
                .ForeignKey("dbo.Beds", t => t.Bed_BedId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .Index(t => t.Bed_BedId)
                .Index(t => t.Patient_PatientId)
                .Index(t => t.Room_RoomId);
            
            CreateTable(
                "dbo.PatientAllergies",
                c => new
                    {
                        PatientAllergiesId = c.Long(nullable: false, identity: true),
                        Allergies_AllergiesId = c.Long(),
                        Patient_PatientId = c.Long(),
                    })
                .PrimaryKey(t => t.PatientAllergiesId)
                .ForeignKey("dbo.Allergies", t => t.Allergies_AllergiesId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Allergies_AllergiesId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Long(nullable: false, identity: true),
                        QuestionInformation = c.String(),
                        Answer = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Referrals",
                c => new
                    {
                        ReferralId = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Patient_PatientId = c.Long(),
                    })
                .PrimaryKey(t => t.ReferralId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ReminderId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        TimeInterval = c.Short(nullable: false),
                        Period = c.DateTime(nullable: false),
                        Description = c.String(),
                        Patient_PatientId = c.Long(),
                    })
                .PrimaryKey(t => t.ReminderId)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientId)
                .Index(t => t.Patient_PatientId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Long(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Comment = c.String(),
                        ReviewType = c.Int(nullable: false),
                        Appointment_AppointmentId = c.Long(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentId)
                .Index(t => t.Appointment_AppointmentId);
            
            CreateTable(
                "dbo.Secretaries",
                c => new
                    {
                        SecretaryId = c.Long(nullable: false, identity: true),
                        Employee_EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.SecretaryId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.StaticInventories",
                c => new
                    {
                        StaticItemId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                        Room_RoomId = c.Long(),
                    })
                .PrimaryKey(t => t.StaticItemId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .Index(t => t.Room_RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaticInventories", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Secretaries", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Reviews", "Appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Reminders", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Referrals", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientAllergies", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientAllergies", "Allergies_AllergiesId", "dbo.Allergies");
            DropForeignKey("dbo.HospitalTreatments", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.HospitalTreatments", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.HospitalTreatments", "Bed_BedId", "dbo.Beds");
            DropForeignKey("dbo.GuestPatients", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.GuestPatients", "Appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Prescriptions", "Anamnesis_AnamnesisId", "dbo.Anamnesis");
            DropForeignKey("dbo.Prescriptions", "Drug_DrugId", "dbo.Drugs");
            DropForeignKey("dbo.Prescriptions", "Doctor_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Patients", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RegisteredUser_Username", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Notifications", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Patients", "MedicalRecord_MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "Anamnesis_AnamnesisId", "dbo.Anamnesis");
            DropForeignKey("dbo.Appointments", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "Doctor_DoctorId", "dbo.Doctors");
            DropIndex("dbo.StaticInventories", new[] { "Room_RoomId" });
            DropIndex("dbo.Secretaries", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Reviews", new[] { "Appointment_AppointmentId" });
            DropIndex("dbo.Reminders", new[] { "Patient_PatientId" });
            DropIndex("dbo.Referrals", new[] { "Patient_PatientId" });
            DropIndex("dbo.PatientAllergies", new[] { "Patient_PatientId" });
            DropIndex("dbo.PatientAllergies", new[] { "Allergies_AllergiesId" });
            DropIndex("dbo.HospitalTreatments", new[] { "Room_RoomId" });
            DropIndex("dbo.HospitalTreatments", new[] { "Patient_PatientId" });
            DropIndex("dbo.HospitalTreatments", new[] { "Bed_BedId" });
            DropIndex("dbo.GuestPatients", new[] { "User_UserId" });
            DropIndex("dbo.GuestPatients", new[] { "Appointment_AppointmentId" });
            DropIndex("dbo.Employees", new[] { "User_UserId" });
            DropIndex("dbo.Notifications", new[] { "User_UserId" });
            DropIndex("dbo.Users", new[] { "RegisteredUser_Username" });
            DropIndex("dbo.MedicalRecords", new[] { "Anamnesis_AnamnesisId" });
            DropIndex("dbo.Patients", new[] { "User_UserId" });
            DropIndex("dbo.Patients", new[] { "MedicalRecord_MedicalRecordId" });
            DropIndex("dbo.Appointments", new[] { "Room_RoomId" });
            DropIndex("dbo.Appointments", new[] { "Patient_PatientId" });
            DropIndex("dbo.Appointments", new[] { "Doctor_DoctorId" });
            DropIndex("dbo.Doctors", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Prescriptions", new[] { "Anamnesis_AnamnesisId" });
            DropIndex("dbo.Prescriptions", new[] { "Drug_DrugId" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_DoctorId" });
            DropTable("dbo.StaticInventories");
            DropTable("dbo.Secretaries");
            DropTable("dbo.Reviews");
            DropTable("dbo.Reminders");
            DropTable("dbo.Referrals");
            DropTable("dbo.Questions");
            DropTable("dbo.PatientAllergies");
            DropTable("dbo.HospitalTreatments");
            DropTable("dbo.HospitalClinics");
            DropTable("dbo.GuestPatients");
            DropTable("dbo.DoctorsReferrals");
            DropTable("dbo.Beds");
            DropTable("dbo.Drugs");
            DropTable("dbo.Employees");
            DropTable("dbo.Rooms");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
            DropTable("dbo.Doctors");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Anamnesis");
            DropTable("dbo.Allergies");
        }
    }
}

namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hospitalDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        appointmentId = c.Long(nullable: false, identity: true),
                        begining = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                        appointmentType = c.Int(nullable: false),
                        appointmentStatus = c.Int(nullable: false),
                        guestPatientId = c.Long(nullable: false),
                        doctor_doctorId = c.Long(),
                        patient_patientId = c.Long(),
                    })
                .PrimaryKey(t => t.appointmentId)
                .ForeignKey("dbo.Doctors", t => t.doctor_doctorId)
                .ForeignKey("dbo.Patients", t => t.patient_patientId)
                .Index(t => t.doctor_doctorId)
                .Index(t => t.patient_patientId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        doctorId = c.Long(nullable: false, identity: true),
                        aboutMe = c.String(),
                        user_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.doctorId)
                .ForeignKey("dbo.Users", t => t.user_UserId)
                .Index(t => t.user_UserId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        prescriptionId = c.Long(nullable: false, identity: true),
                        dosage = c.Int(nullable: false),
                        usage = c.String(),
                        period = c.String(),
                        date = c.DateTime(nullable: false),
                        Doctor_doctorId = c.Long(),
                        Patient_patientId = c.Long(),
                    })
                .PrimaryKey(t => t.prescriptionId)
                .ForeignKey("dbo.Doctors", t => t.Doctor_doctorId)
                .ForeignKey("dbo.Patients", t => t.Patient_patientId)
                .Index(t => t.Doctor_doctorId)
                .Index(t => t.Patient_patientId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        dateOfBirth = c.DateTime(nullable: false),
                        address = c.String(),
                        phoneNumber = c.String(),
                        jmbg = c.Int(nullable: false),
                        eMail = c.String(),
                        sex = c.Int(nullable: false),
                        registeredUser_regUserId = c.Long(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.RegisteredUsers", t => t.registeredUser_regUserId)
                .Index(t => t.registeredUser_regUserId);
            
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        regUserId = c.Long(nullable: false, identity: true),
                        encryptedID = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.regUserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        patientId = c.Long(nullable: false, identity: true),
                        anamnesis_anamnesisId = c.Long(),
                    })
                .PrimaryKey(t => t.patientId)
                .ForeignKey("dbo.Anamnesis", t => t.anamnesis_anamnesisId)
                .Index(t => t.anamnesis_anamnesisId);
            
            CreateTable(
                "dbo.Anamnesis",
                c => new
                    {
                        anamnesisId = c.Long(nullable: false, identity: true),
                        lastMesuredHeight = c.Single(nullable: false),
                        lastMesuredWeight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.anamnesisId);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        medicalRecordId = c.Long(nullable: false, identity: true),
                        timeOf = c.DateTime(nullable: false),
                        description = c.String(),
                        Anamnesis_anamnesisId = c.Long(),
                    })
                .PrimaryKey(t => t.medicalRecordId)
                .ForeignKey("dbo.Anamnesis", t => t.Anamnesis_anamnesisId)
                .Index(t => t.Anamnesis_anamnesisId);
            
            CreateTable(
                "dbo.GuestPatients",
                c => new
                    {
                        guestPatientId = c.Int(nullable: false, identity: true),
                        arrivalDate = c.DateTime(nullable: false),
                        emergencyInfo = c.String(),
                        appointment_appointmentId = c.Long(),
                        user_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.guestPatientId)
                .ForeignKey("dbo.Appointments", t => t.appointment_appointmentId)
                .ForeignKey("dbo.Users", t => t.user_UserId)
                .Index(t => t.appointment_appointmentId)
                .Index(t => t.user_UserId);
            
            CreateTable(
                "dbo.Secretaries",
                c => new
                    {
                        secretaryId = c.Long(nullable: false, identity: true),
                        user_UserId = c.Long(),
                    })
                .PrimaryKey(t => t.secretaryId)
                .ForeignKey("dbo.Users", t => t.user_UserId)
                .Index(t => t.user_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secretaries", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.GuestPatients", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.GuestPatients", "appointment_appointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Prescriptions", "Patient_patientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "patient_patientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "anamnesis_anamnesisId", "dbo.Anamnesis");
            DropForeignKey("dbo.MedicalRecords", "Anamnesis_anamnesisId", "dbo.Anamnesis");
            DropForeignKey("dbo.Doctors", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "registeredUser_regUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Prescriptions", "Doctor_doctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "doctor_doctorId", "dbo.Doctors");
            DropIndex("dbo.Secretaries", new[] { "user_UserId" });
            DropIndex("dbo.GuestPatients", new[] { "user_UserId" });
            DropIndex("dbo.GuestPatients", new[] { "appointment_appointmentId" });
            DropIndex("dbo.MedicalRecords", new[] { "Anamnesis_anamnesisId" });
            DropIndex("dbo.Patients", new[] { "anamnesis_anamnesisId" });
            DropIndex("dbo.Users", new[] { "registeredUser_regUserId" });
            DropIndex("dbo.Prescriptions", new[] { "Patient_patientId" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_doctorId" });
            DropIndex("dbo.Doctors", new[] { "user_UserId" });
            DropIndex("dbo.Appointments", new[] { "patient_patientId" });
            DropIndex("dbo.Appointments", new[] { "doctor_doctorId" });
            DropTable("dbo.Secretaries");
            DropTable("dbo.GuestPatients");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Anamnesis");
            DropTable("dbo.Patients");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Users");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}

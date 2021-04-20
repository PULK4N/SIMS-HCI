﻿namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anamnesis",
                c => new
                    {
                        AnamnesisId = c.Long(nullable: false, identity: true),
                        TimeOf = c.DateTime(nullable: false),
                        Description = c.String(),
                        Prescription_PrescriptionId = c.Long(),
                        MedicalRecord_MedicalRecordId = c.Long(),
                    })
                .PrimaryKey(t => t.AnamnesisId)
                .ForeignKey("dbo.Prescriptions", t => t.Prescription_PrescriptionId)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecord_MedicalRecordId)
                .Index(t => t.Prescription_PrescriptionId)
                .Index(t => t.MedicalRecord_MedicalRecordId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        PrescriptionId = c.Long(nullable: false, identity: true),
                        Dosage = c.Int(nullable: false),
                        Usage = c.String(),
                        Period = c.String(),
                        Date = c.DateTime(nullable: false),
                        Doctor_DoctorId = c.Long(),
                    })
                .PrimaryKey(t => t.PrescriptionId)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorId)
                .Index(t => t.Doctor_DoctorId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                        Prescription_PrescriptionId = c.Long(),
                    })
                .PrimaryKey(t => t.MedicineId)
                .ForeignKey("dbo.Prescriptions", t => t.Prescription_PrescriptionId)
                .Index(t => t.Prescription_PrescriptionId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Long(nullable: false, identity: true),
                        Begining = c.DateTime(nullable: false),
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
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Long(nullable: false, identity: true),
                        AboutMe = c.String(),
                        Specialization = c.Int(nullable: false),
                        Name = c.String(),
                        Employee_EmployeeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId);
            
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
                        RelationshipStatus = c.Int(nullable: false),
                        RegisteredUser_RegUserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUser_RegUserId, cascadeDelete: true)
                .Index(t => t.RegisteredUser_RegUserId);
            
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
                        RegUserId = c.Long(nullable: false, identity: true),
                        EncryptedID = c.String(),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegUserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Long(nullable: false, identity: true),
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
                    })
                .PrimaryKey(t => t.MedicalRecordId);
            
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
                "dbo.Referals",
                c => new
                    {
                        ReferalId = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Date = c.DateTime(nullable: false),
                        Appointment_AppointmentId = c.Long(),
                    })
                .PrimaryKey(t => t.ReferalId)
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentId)
                .Index(t => t.Appointment_AppointmentId);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ReminderId = c.Long(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ReminderId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Long(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ReviewId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secretaries", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Referals", "Appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.GuestPatients", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.GuestPatients", "Appointment_AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Patients", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Patients", "MedicalRecord_MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.Anamnesis", "MedicalRecord_MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.Appointments", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "Doctor_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RegisteredUser_RegUserId", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Notifications", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Doctor_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Anamnesis", "Prescription_PrescriptionId", "dbo.Prescriptions");
            DropForeignKey("dbo.Medicines", "Prescription_PrescriptionId", "dbo.Prescriptions");
            DropIndex("dbo.Secretaries", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Referals", new[] { "Appointment_AppointmentId" });
            DropIndex("dbo.GuestPatients", new[] { "User_UserId" });
            DropIndex("dbo.GuestPatients", new[] { "Appointment_AppointmentId" });
            DropIndex("dbo.Patients", new[] { "User_UserId" });
            DropIndex("dbo.Patients", new[] { "MedicalRecord_MedicalRecordId" });
            DropIndex("dbo.Notifications", new[] { "User_UserId" });
            DropIndex("dbo.Users", new[] { "RegisteredUser_RegUserId" });
            DropIndex("dbo.Employees", new[] { "User_UserId" });
            DropIndex("dbo.Doctors", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Appointments", new[] { "Room_RoomId" });
            DropIndex("dbo.Appointments", new[] { "Patient_PatientId" });
            DropIndex("dbo.Appointments", new[] { "Doctor_DoctorId" });
            DropIndex("dbo.Medicines", new[] { "Prescription_PrescriptionId" });
            DropIndex("dbo.Prescriptions", new[] { "Doctor_DoctorId" });
            DropIndex("dbo.Anamnesis", new[] { "MedicalRecord_MedicalRecordId" });
            DropIndex("dbo.Anamnesis", new[] { "Prescription_PrescriptionId" });
            DropTable("dbo.Secretaries");
            DropTable("dbo.Reviews");
            DropTable("dbo.Reminders");
            DropTable("dbo.Referals");
            DropTable("dbo.Questions");
            DropTable("dbo.HospitalClinics");
            DropTable("dbo.GuestPatients");
            DropTable("dbo.DoctorsReferrals");
            DropTable("dbo.Rooms");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Patients");
            DropTable("dbo.RegisteredUsers");
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
            DropTable("dbo.Medicines");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Anamnesis");
        }
    }
}
//using FluentAssertions;
//using JKCore.Models;
//using System;
//using Xunit;

//namespace JKCore.Test.Models
//{
//    public class DoctorTest
//    {
//        [Fact]
//        public void doctor_default_value_must()
//        {
//            // Arrange / Actions.
//            var doctor = Doctor.Create();


//            // Assertion
//            doctor.Address.Should().BeNullOrEmpty();
//            doctor.City.Should().BeNullOrEmpty();
//            doctor.Clinics.Should().BeEmpty();
//            doctor.Country.Should().BeNullOrEmpty();
//            doctor.CreatedDate.Should().Be(DateTime.MinValue);
//            doctor.Email.Should().BeNullOrEmpty();
//            doctor.FirstName.Should().BeNullOrEmpty();
//            doctor.LastName.Should().BeNullOrEmpty();
//            doctor.Id.Should().BeNullOrEmpty();
//            doctor.IsDeleted.Should().BeFalse();
//            doctor.LastName.Should().BeNullOrEmpty();
//            Math.Abs(doctor.Latitude).Should().BeGreaterThan(90);
//            Math.Abs(doctor.Longitude).Should().BeGreaterThan(180);
//            doctor.Phone.Should().BeNullOrEmpty();
//            doctor.State.Should().BeNullOrEmpty();
//            doctor.UpdatedDate.Should().Be(DateTime.MinValue);
//            doctor.UserId.Should().BeNullOrEmpty();
//            doctor.Ward.Should().BeNullOrEmpty();
//        }
//    }
//}

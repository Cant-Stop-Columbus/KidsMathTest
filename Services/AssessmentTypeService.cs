using FluencyMath.Lib;
using System;
using System.Collections.Generic;

namespace FluencyMath.Services
{
    public class AssessmentTypeService
    {

        public List<AssessmentType> Fetch()
        {
            var assessmentTypes = new List<AssessmentType>();

            var aType1 = new AssessmentType();
            aType1.Id = Guid.Parse("c256ee6b-9bae-4b74-a95f-8eb061082220");
            aType1.Name ="Assessment 1";
            aType1.Description = "Addition 0-20 [0-10 + 0-10]";
            aType1.OrderId = 1;
            assessmentTypes.Add(aType1);

            var aType2 = new AssessmentType();
            aType2.Id = Guid.Parse("c97657b7-f79d-449f-9c9b-8737256f903a");
            aType2.Name = "Assessment 2";
            aType2.Description = "Subtraction 0-20 [1-20 - 0-19 answer > 0]";
            aType2.OrderId = 2;
            assessmentTypes.Add(aType2);

            var aType3 = new AssessmentType();
            aType3.Id = Guid.Parse("c2227122-85ef-4eab-815b-0467d1805c08");
            aType3.Name = "Assessment 3";
            aType3.Description = "Two-digit addition without regrouping [0-99 + 0-99 without “carrying” answer <= 99]";
            aType3.OrderId = 3;
            assessmentTypes.Add(aType3);

            var aType4 = new AssessmentType();
            aType4.Id = Guid.Parse("727e7827-ad2a-4723-a60c-20396d13932e");
            aType4.Name = "Assessment 4";
            aType4.Description = "Two-digit addition with regrouping [0-99 + 0-99 with “carrying” answer <= 99]";
            aType4.OrderId = 4;
            assessmentTypes.Add(aType4);

            var aType5 = new AssessmentType();
            aType5.Id = Guid.Parse("dbf323e0-58f3-4be4-b964-feeed27a7bbf");
            aType5.Name = "Assessment 5";
            aType5.Description = "Two-digit subtraction without regrouping [0-99 - 0-99 without “borrowing” answer > 0]";
            aType5.OrderId = 5;
            assessmentTypes.Add(aType5);

            var aType6 = new AssessmentType();
            aType6.Id = Guid.Parse("4240e76c-5bda-426b-8bc1-563f77245aba");
            aType6.Name = "Assessment 6";
            aType6.Description = "Two-digit subtraction with regrouping [0-99 - 0-99 with “borrowing” answer > 0]";
            aType6.OrderId = 6;
            assessmentTypes.Add(aType6);

            var aType7 = new AssessmentType();
            aType7.Id = Guid.Parse("a5b26405-47b2-4cf8-862f-5bc5a2ffb544");
            aType7.Name = "Assessment 7";
            aType7.Description = "Three-digit addition without regrouping [0-999 + 0-999 without “carrying” answer <= 999]";
            aType7.OrderId = 7;
            assessmentTypes.Add(aType7);

            var aType8 = new AssessmentType();
            aType8.Id = Guid.Parse("da078d8a-8bb6-4735-8bf0-49defeb4ef3e");
            aType8.Name = "Assessment 8";
            aType8.Description = "Three-digit addition with regrouping [0-999 + 0-999 with “carrying” answer <= 999]";
            aType8.OrderId = 8;
            assessmentTypes.Add(aType8);

            return assessmentTypes;

        }
    }
}

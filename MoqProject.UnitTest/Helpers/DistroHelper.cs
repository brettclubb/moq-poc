using System;
using MoqProject.API.Models;

namespace MoqProject.UnitTest.Helpers
{
	public static class DistroHelper
	{
        public static List<Contact> GenerateFakeContactList(int count)
        {
            var distro = new List<Contact>();

            for (int i = 0; i < count; i++)
            {
                distro.Add(new Contact
                {
                    UserId = $"user{i}",
                    Email = $"user{i}@email.com",
                    FirstName = $"First{i}",
                    LastName = $"Last{i}"
                });
            }

            return distro;
        }

        public static DistributionList GenerateFakeDistro()
        {
            return new DistributionList
            {
                Title = $"Distro 1 Title",
                Contacts = GenerateFakeContactList(5)
            };
        }

        public static List<DistributionList> GenerateFakeDistros(int count)
        {
            var distro = new List<DistributionList>();

            for (int i = 0; i < count; i++)
            {
                distro.Add(new DistributionList
                {
                    Id = i,
                    Title = $"Distro {i} Title",
                    Contacts = GenerateFakeContactList(i * 5)
                });
            }

            return distro;
        }
    }
}


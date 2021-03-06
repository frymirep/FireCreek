﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Domain;
using Services;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void POSTTest()
        {
            var input = new GeoLocation
                               {
                                   Accuracy = 1.26743233E+14,
                                   Altitude = 1.26743233E+14,
                                   AltitudeAccuracy = 1.26743233E+14,
                                   Heading = 1.26743233E+14,
                                   Latitude = 1.26743233E+14,
                                   Longitude = 1.26743233E+14,
                                   Speed = 1.26743233E+14,
                                   Timestamp = DateTime.Parse("1999-05-31T11:20:00")
                               };
            GeoLocation output = null;
            var factory = new ChannelFactory<IService<GeoLocation>>("GeoLocationService");
            if (factory.State != CommunicationState.Faulted)
            {
                var proxy = factory.CreateChannel();
                try
                {                    
                    output = proxy.Create(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.InnerException.StackTrace);
                }
                Console.WriteLine(output.Identifier);
                if (factory.State == CommunicationState.Faulted)
                {
                    factory.Abort();
                }
                ((IDisposable)proxy).Dispose();
            }

            Assert.IsNotNull(output);
        }
        [TestMethod]
        public void GETTest()
        {
            GeoLocation output = null;
            var factory = new ChannelFactory<IService<GeoLocation>>("GeoLocationService");
            if (factory.State != CommunicationState.Faulted)
            {
                var proxy = factory.CreateChannel();
                output = proxy.Read("werwtw4hej3u");
                Console.WriteLine(output.Identifier);
                if (factory.State == CommunicationState.Faulted)
               {
                    factory.Abort();
                }
                ((IDisposable)proxy).Dispose();
            }

            Assert.IsNotNull(output);
        }
    }
}
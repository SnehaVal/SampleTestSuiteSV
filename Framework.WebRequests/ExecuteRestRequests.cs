using System.Collections.Generic;
using Framework.WebRequests.ClassModels;
using RestSharp;

namespace Framework.WebRequests
{
    public class ExexuteRestRequests
    {
        const string _Accept = "Accept";
        const string _ContentType = "Content-Type";
        const string _Authorisaton = "Authorization";
        const string logonURL = "https://qacandidatetest.ensek.io/ENSEK/login";
        const string resetURL = "https://qacandidatetest.ensek.io/ENSEK/reset";
        const string getEnergyURL = "https://qacandidatetest.ensek.io/ENSEK/energy";
        const string buyEnergyURL = "https://qacandidatetest.ensek.io/ENSEK/buy";
        const string getOrderDetailsURL = "https://qacandidatetest.ensek.io/ENSEK/orders";
        const string contentType = "application/json";
        const string authorization = "Bearer sample003";


        public static LoginResponse LogOnToAccount()
        {
            var client = new RestClient(logonURL);
            LoginRequest credentials = new LoginRequest
            {
                username = "test",
                password = "testing"
            };
            var request = new RestRequest(Method.POST);
            request.AddHeader(_Accept, contentType);
            request.AddHeader(_ContentType, contentType);
            request.AddHeader(_Authorisaton, authorization);
            request.AddJsonBody(credentials);

            var response = client.Execute<LoginResponse>(request).Data;
            return response;
        }

        public static ResetResponse ResetTheData()
        {
            var client = new RestClient(resetURL);
            var request = new RestRequest(Method.POST);
            request.AddHeader(_Accept, contentType);
            request.AddHeader(_Authorisaton, authorization);
            var response = client.Execute<ResetResponse>(request).Data;
            return response;
        }

        public static Dictionary<string, EnergyDetails> GetEnergyDetails()
        {
            var client = new RestClient(getEnergyURL);
            var request = new RestRequest(Method.GET);
            request.AddHeader(_Accept, contentType);
            request.AddHeader(_Authorisaton, authorization);
            var response = client.Execute<Dictionary<string, EnergyDetails>>(request).Data;
            return response;
        }

        public static BuyEnergyResponse BuyEnergy(int energyId, int quantity)
        {
            var url = $"{buyEnergyURL}/{energyId}/{quantity}";
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader(_Accept, contentType);
            request.AddHeader(_Authorisaton, authorization);
            var response = client.Execute<BuyEnergyResponse>(request).Data;
            return response;
        }

        public static List<OrderDetailsResponse> GetOrderDetails()
        {
            var client = new RestClient(getOrderDetailsURL);
            var request = new RestRequest(Method.GET);
            request.AddHeader(_Accept, contentType);
            request.AddHeader(_Authorisaton, authorization);
            var response = client.Execute<List<OrderDetailsResponse>>(request).Data;
            return response;
        }

    }
}

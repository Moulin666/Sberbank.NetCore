using Newtonsoft.Json;
using Sberbank.NetCore.Integration.Implementation;
using Sberbank.NetCore.Integration.Implementation.Payment;
using Sberbank.NetCore.Integration.Interfaces;
using Sberbank.NetCore.Responses;
using Sberbank.NetCore.Tools;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sberbank.NetCore
{
    /// <summary>
    /// Client for send request to Sberbank API.
    /// </summary>
    public class SberbankClient
    {
        private string ProductionServerUrl { get; } = "https://securepayments.sberbank.ru/payment/rest";
        private string SandboxTestServerUrl { get; } = "https://3dsec.sberbank.ru/payment/rest";

        private const string PostRequest = WebRequestMethods.Http.Post;
        private const string GetRequest = WebRequestMethods.Http.Get;

        /// <summary>
        /// Sandbox mode.
        /// </summary>
        public bool SandboxMode { get; set; }

        private string ServerUrl
        {
            get
            {
                if (SandboxMode)
                    return SandboxTestServerUrl;

                return ProductionServerUrl;
            }
        }

        private readonly IParameters authSettings;

        public SberbankClient(string username, string password, bool sandboxMode = true)
            : this(new AuthSettings(username, password), sandboxMode) { }

        public SberbankClient(AuthSettings authSettings, bool sandboxMode = true)
        {
            this.authSettings = authSettings;
            SandboxMode = sandboxMode;
        }

        #region Register

        public RegisterOrderResponse RegisterOrder(RegisterPaymentParameters args)
        {
            var request = RegisterOrderAsync(args);
            request.Wait();

            return request.Result;
        }

        public Task<RegisterOrderResponse> RegisterOrderAsync(RegisterPaymentParameters parameters)
            => Request<RegisterOrderResponse>("register.do", parameters, GetRequest);

        #endregion

        #region Reverse

        public ReverseResponse Reverse(string orderId) => Reverse(new ReverseParameters(orderId));

        public ReverseResponse Reverse(ReverseParameters parameters)
        {
            var request = ReverseAsync(parameters);
            request.Wait();

            return request.Result;
        }

        public Task<ReverseResponse> ReverseAsync(string orderId)
            => ReverseAsync(new ReverseParameters(orderId));

        public Task<ReverseResponse> ReverseAsync(ReverseParameters parameters)
            => Request<ReverseResponse>("reverse.do", parameters, GetRequest);

        #endregion

        #region Refund

        public RefundResponse Refund(string orderId, Price amount) => Refund(new RefundParameters(orderId, amount));

        public RefundResponse Refund(RefundParameters parameters)
        {
            var request = RefundAsync(parameters);
            request.Wait();

            return request.Result;
        }

        public Task<RefundResponse> RefundAsync(string orderId, Price amount)
            => RefundAsync(new RefundParameters(orderId, amount));

        public Task<RefundResponse> RefundAsync(RefundParameters parameters)
            => Request<RefundResponse>("refund.do", parameters, GetRequest);
       
        #endregion

        #region GetOrderStatus

        public GerOrderStatusResponse GetOrderStatus(string orderId)
            => GetOrderStatus(new GetOrderStatusParameters(orderId));

        public GerOrderStatusResponse GetOrderStatus(GetOrderStatusParameters parameters)
        {
            var request = GetOrderStatusAsync(parameters);
            request.Wait();

            return request.Result;
        }

        public Task<GerOrderStatusResponse> GetOrderStatusAsync(string orderId)
            => GetOrderStatusAsync(new GetOrderStatusParameters(orderId));

        public Task<GerOrderStatusResponse> GetOrderStatusAsync(GetOrderStatusParameters parameters)
            => Request<GerOrderStatusResponse>("getOrderStatus.do", parameters, GetRequest);

        #endregion

        #region PaymentOrderBinding

        public PaymentOrderBindingResponse PaymentOrderBinding(PaymentOrderBindingParameters parameters)
        {
            var request = PaymentOrderBindingAsync(parameters);
            request.Wait();

            return request.Result;
        }

        public Task<PaymentOrderBindingResponse> PaymentOrderBindingAsync(PaymentOrderBindingParameters parameters)
            => Request<PaymentOrderBindingResponse>("paymentOrderBinding.do", parameters, PostRequest);

        #endregion

        private async Task<TRestResponse> Request<TRestResponse> (string action, IParameters arguments, string method)
            where TRestResponse : RestResponse
        {
            var parameters = arguments.CollectParameters();
            foreach (var auth in authSettings.CollectParameters())
                parameters.Add(auth.Key, auth.Value);

            var builder = new UriBuilder($"{ServerUrl}/{action}");
            var query = HttpUtility.ParseQueryString(builder.Query);

            foreach (var pair in parameters)
            {
                var type = pair.Value.GetType();
                if (type.IsPrimitive || type == typeof (string))
                    query[pair.Key] = pair.Value.ToString();
                else
                    query[pair.Key] = JsonConvert.SerializeObject(pair.Value);
            }

            builder.Query = query.ToString();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                   | SecurityProtocolType.Tls11
                                                   | SecurityProtocolType.Tls12;

            var request = (HttpWebRequest)WebRequest.Create(builder.ToString());

            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = method;
            request.ContentType = "application/json";
            request.Proxy = null;

            using (var response = await request.GetResponseAsync())
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                var content = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<TRestResponse>(content);
            }
        }
    }
}

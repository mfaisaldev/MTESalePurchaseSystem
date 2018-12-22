using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin
{
    public static class Utilities
    {
        public const string Default_Image = "7f494b02-8b3d-4833-b450-f1bb6f6c0850";
        // VISMA URL
       
       // public const string URL = "http://138.91.58.109:9000/api/";
        public const string URL = "http://109.68.180.91:9001/api/";

        public const string StatusType_CURD = "3abe2213-aa9d-401e-ba4b-604d0a990af9";
        public const string Status_Active = "a0a990b4-6c4f-4463-a3af-ae2abf789bd6";
        public const string Status_InActive = "2988d3fd-b4e6-41c7-9969-b8acdd6c9a43";

        public const string Status_Delete = "7bdff3c9-ac23-46fb-bb27-3369903ce98e";
        public const string StatusType_Delete = "a2d6573d-f4d1-4f58-bc84-c35335a46f2f";

        public const string Status_Online = "77561828-5798-4aad-a15d-3c6f522fbaae";
        public const string Status_Under_Porcess = "3b519c6e-2c43-469a-9ffc-4c3ff99860be";
        public const string Status_Block = "ace26b8e-3b74-4f17-aadf-826a9b34d839";
        public const string StatusType_User = "d524e27a-5496-4f5c-b542-4a8f151dafb6";
        //Order
        public const string Order_In_Process = "16132254-ce43-46a6-af52-1868a4975b94";
        public const string Order_Partially_Delivered = "5d3f25aa-2c52-4837-995a-0018a5779930";
        public const string Order_Initialized = "a567cf6b-aae8-4086-bc53-d3571b942292";
        public const string Order_Delivered = "2695ca43-2401-4423-b42e-d4c8bea74618";
        public const string StatusType_Order = "e3a68456-1dbe-44a6-95e7-c1ac3cfad684";


        //Purchas Order
        public const string Purchas_Order_Partially_Delivered = "c3d92a7e-15c8-4622-8172-152549d9b12b";
        public const string Purchas_Order_In_Process = "4b4eff15-6e9c-47c6-8d6a-30c0acbb9da6";
        public const string Purchas_Order_Initialized = "98279a7a-e06b-46e4-b292-49fd088ca052";
        public const string Purchas_Order_Approved = "889bbcfe-bd62-4e4b-9337-81bfdfcda6a1";
        public const string Purchas_Order_Rejected = "0b805fad-59ad-43b7-a8bd-9c778be36bfb";
        public const string Purchase_Order_Delivered = "4120b625-ba61-402a-acfc-f93f7ab23001";
        public const string Purchase_Order_Supplier_Rejected = "1e9cb2dd-9603-43de-8d29-7764c0766ae7";
        public const string Purchase_Order_Supplier_Accepted = "23341d84-b353-4b5a-aec4-0f5d3d43ee49";

        //Offer Status
        public const string Status_Complete = "87491619-4094-4ba4-9e2a-0e0a63f31c3c";
        public const string Status_Finally_Rejected = "97edd0a3-8ae8-4153-830d-102e6b1628db";
        public const string Status_Customer_Rejected = "7e3f9709-57a0-4e82-8621-21dd72d894f6";
        public const string Status_Initially_Rejected = "e467b91f-2a09-46da-abe9-307772a0b5c5";
        public const string Status_Customer_Accepted = "49f96a2a-0d12-4efd-9808-3ec36fd2f573";
        public const string Status_Finally_Approved = "a371819a-6289-4bbb-9d0f-6b86f890a6ef";
        public const string Status_Initially_in_Process = "e5084fa5-1e66-43c0-a7c1-903e9d23e559";
        public const string Status_Initialize = "1597b2a4-a948-4adc-aa4c-e3a45ee39614";
        public const string Status_Initially_Approved = "66ab70c9-446a-4713-9687-f8ed64207736";
        public const string Status_Finally_in_Process = "25b83e80-35fa-4aa3-b1d3-ffc6ec6546eb";


        public const string Menu_Role = "754598D9-05C2-495A-8AED-00607853D354";
        public const string Menu_Dashboard = "AD04D40A-D10B-47E2-B98A-3E2FD354831B";
        public const string Menu_Order = "ED4DCBA8-2C0A-432C-9E96-7A40E0ED51F9";
        public const string Menu_Offers = "84A95E95-095C-4E67-8151-99406FC6342A";
        public const string Menu_Product = "284F83B4-6DAA-4A9F-B58F-A49E14C1FD0E";
        public const string Menu_Product_StockInfo = "6EBBB430-DD4B-4DA4-9170-413A84DBAA4A";
        public const string Menu_Customer_Sub = "61487C6A-9C7E-4C83-B3A0-B0864C87FCE5";
        public const string Menu_Stock_Reconciliation = "98D8E88F-AE97-4D23-99FC-CAF0776515C0";
        public const string Menu_Shipment = "0FCB624C-4D40-4C17-AAD7-B574F46352DE";
        public const string Menu_Category = "C68A184B-3749-4101-A8DC-F79443DF45A5";
        public const string Menu_Full_Sales = "7C86906F-1ADE-4475-A296-A5042DF0D8ED";
        public const string Menu_Customer_Approval = "58B7E573-0489-40AE-8475-2C2B31111FF4";
        public const string Menu_Access_Control_List = "C2BD7707-31A9-4D11-9B72-76CB620A1FDC";
        public const string Menu_Catalog = "1CC660E5-B7A5-4D41-AC8B-5C9AB7A35BA3";
        public const string Menu_Scheduler_Task = "AA5C980C-5D4B-4106-B2D8-013C843D8163";
        public const string Menu_Brand = "FF6ECF3B-85D8-41CD-B104-0DBFBCB20BF9";
        public const string Menu_Supplier = "716076D5-C4F1-402A-8495-AB55244A0144";
        public const string Menu_Specific = "1A24A21B-39E1-4213-8938-E51AAF7942D3";
        public const string Menu_Sales = "42003546-AEA7-4FB0-9650-F77E84F3EA98";
        public const string Menu_Customer = "E86BFC69-9EAF-4EC4-8A39-76B08400774B";
        public const string Menu_Country = "EAFA9F50-FBFC-499E-9A43-7CD321C563FF";
        public const string Menu_Purchase_Orders = "89C20BF5-153A-45B4-92B1-814EF0A6A217";
        public const string Menu_Email = "C2251C23-DF61-4380-9E54-8D41561BF811";
        public const string Menu_Email_Template = "8084CBF9-1F8F-4840-8EA5-B83EF5C44D17";
        public const string Menu_Promotions = "CD4D27F5-F203-48D1-858F-CD9A28966BAB";
        public const string Menu_Configuration = "EA1D7227-D4DC-4A2E-BE52-A6878CE9BC56";
        public const string Menu_Report = "947EF39E-48E2-4C1F-85E0-62234338E036";
        public const string Menu_Currency = "22A9E7CD-A900-42C5-AC00-B66AC42ADBBF";
        public const string Menu_Unit = "52A825EF-5E2C-4263-B369-D0A6DC66F2B1";
        public const string Menu_SubGroup = "CEEA7219-B68E-4E9A-BD30-22D81252AC01";
        public const string Menu_IntermediateGroup = "F0766BF4-F729-4935-9989-8802B5106262";
        public const string Menu_MainGroup = "AC87CB88-C408-4816-9C0E-C1D948632A78";
        public const string Menu_Employee = "901445DD-A329-4331-A663-A1CB1734648D";

        public const string Role_CFO = "DA9D0B06-EF65-4339-A7F3-08BC8B467518";
        public const string Role_Admin = "40E094B8-2771-4D32-B0F7-124EB74999F6";
        public const string Role_Sales_Representative = "6C07FF63-A287-4206-B8C6-35C279F34FA2";
        public const string Role_Supplier = "50DD4521-B93B-45DF-9983-36661E9A7292";
        public const string Role_Sales_Manager = "82695374-BC79-483A-8774-39C860EE110F";
        public const string Role_Customer = "1A5D23F3-A628-4702-9211-3BFE30114460";
        public const string Role_Operations = "34C7078B-2899-4C7B-82F2-64C5F6AE7C9A";


    }
}
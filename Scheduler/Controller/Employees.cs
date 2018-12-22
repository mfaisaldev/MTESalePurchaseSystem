using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Admin;

namespace Scheduler.Controller
{
    class Employees
    {
        private const string URL = Utilities.URL + "employees";
        private string urlParameters = "";
        public async Task GetEmployees()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsAsync<JObject>();
                    if (!(json[Employee.ARRAY_Employee] is JArray)) return;
                    var col = (JArray)json[Employee.ARRAY_Employee];
                    foreach (JObject obj in col)
                    {
                        this.AddEmployee(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void AddEmployee(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var EmployeeNo = Convert.ToInt32(obj[Employee.EmployeeNo]);
                    var oldt = DB.vEmployees.Where(u => u.EmployeeNo == EmployeeNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vEmployee();
                        t.EmployeeNo = Convert.ToInt32(obj[Employee.EmployeeNo]);
                        t.Name = Convert.ToString(obj[Employee.Name]);
                        t.Titel = Convert.ToString(obj[Employee.Titel]);
                        t.DepNo = Convert.ToInt32(obj[Employee.DepNo]);
                        t.InternalTelephone = Convert.ToString(obj[Employee.InternalTelephone]);
                        t.MobileTelephone = Convert.ToString(obj[Employee.MobileTelephone]);
                        t.CountryNo = Convert.ToInt32(obj[Employee.CountryNo]);
                        t.PostOffice = Convert.ToString(obj[Employee.PostOffice]);
                        t.PostCode = Convert.ToString(obj[Employee.PostCode]);
                        t.Address1 = Convert.ToString(obj[Employee.Address1]);
                        t.CommissionNo = Convert.ToInt32(obj[Employee.CommissionNo]);
                        t.Telefax = Convert.ToString(obj[Employee.Telefax]);
                        t.PrivateTelephone = Convert.ToString(obj[Employee.PrivateTelephone]);
                        t.HireDate = Convert.ToDateTime(obj[Employee.HireDate]);
                        t.ReportsTo = Convert.ToInt32(obj[Employee.ReportsTo]);
                        t.NameReportsTo = Convert.ToString(obj[Employee.NameReportsTo]);
                        t.InActiveYesNo = Convert.ToBoolean(obj[Employee.InActiveYesNo]);
                        t.BankAccount = Convert.ToString(obj[Employee.BankAccount]);
                        t.PostAccount = Convert.ToString(obj[Employee.PostAccount]);
                        t.InternalEmailAddress = Convert.ToString(obj[Employee.InternalEmailAddress]);
                        t.PrivateEmailAddress = Convert.ToString(obj[Employee.PrivateEmailAddress]);
                        t.ProjectNo = Convert.ToInt32(obj[Employee.ProjectNo]);
                        t.ProductNo = Convert.ToInt32(obj[Employee.ProductNo]);
                        t.Address3 = Convert.ToString(obj[Employee.Address3]);
                        t.Address2 = Convert.ToString(obj[Employee.Address2]);
                        t.LastUpdate = Convert.ToDateTime(obj[Employee.LastUpdate]);
                        t.NickName = Convert.ToString(obj[Employee.NickName]);
                        t.BusyReason = Convert.ToString(obj[Employee.BusyReason]);
                        t.BusyStatus = Convert.ToBoolean(obj[Employee.BusyStatus]);
                        t.EndedDate = Convert.ToDateTime(obj[Employee.EndedDate]);
                        t.Sex = Convert.ToInt32(obj[Employee.Sex]);
                        t.Bleeper = Convert.ToString(obj[Employee.Bleeper]);
                        t.PersonalWWWAddress = Convert.ToString(obj[Employee.PersonalWWWAddress]);
                        t.UserNo = Convert.ToInt32(obj[Employee.UserNo]);
                        t.Birthday = Convert.ToString(obj[Employee.Birthday]);
                        t.MiddleName = Convert.ToString(obj[Employee.MiddleName]);
                        t.FamilyName = Convert.ToString(obj[Employee.FamilyName]);
                        t.ParentFamilyName = Convert.ToString(obj[Employee.ParentFamilyName]);
                        t.ParentName = Convert.ToString(obj[Employee.ParentName]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[Employee.LastUpdatedBy]);
                        t.Created = Convert.ToDateTime(obj[Employee.Created]);
                        t.CreatedBy = Convert.ToInt32(obj[Employee.CreatedBy]);
                        t.EbusinessType = Convert.ToInt32(obj[Employee.EbusinessType]);
                        t.Password = Convert.ToString(obj[Employee.Password]);
                        t.PLUser = Convert.ToInt32(obj[Employee.PLUser]);
                        t.TSApproverEmployeeNo = Convert.ToInt32(obj[Employee.TSApproverEmployeeNo]);
                        t.DeviationControlYesNo = Convert.ToBoolean(obj[Employee.DeviationControlYesNo]);
                        t.SubstManagerYesNo = Convert.ToBoolean(obj[Employee.SubstManagerYesNo]);
                        t.EmployeeCatNo = Convert.ToInt32(obj[Employee.EmployeeCatNo]);
                        t.TimeCostPrice = Convert.ToInt32(obj[Employee.TimeCostPrice]);
                        t.TimeSalesPrice = Convert.ToInt32(obj[Employee.TimeSalesPrice]);
                        t.WorkingHours = Convert.ToInt32(obj[Employee.WorkingHours]);
                        t.AllowTimeSheetRegAllUsers = Convert.ToBoolean(obj[Employee.AllowTimeSheetRegAllUsers]);
                        t.UseWagesortYesNo = Convert.ToInt32(obj[Employee.UseWagesortYesNo]);
                        t.TimeWgSrtNo = Convert.ToInt32(obj[Employee.TimeWgSrtNo]);
                        t.DeputyNo = Convert.ToInt32(obj[Employee.DeputyNo]);
                        t.MaxAttestationAmount = Convert.ToInt32(obj[Employee.MaxAttestationAmount]);
                        t.SuperiorNo = Convert.ToInt32(obj[Employee.SuperiorNo]);
                        t.WareHouseNo = Convert.ToInt32(obj[Employee.WorkingHours]);
                        t.IsUpdated = true;
                        DB.vEmployees.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.Name != Convert.ToString(obj[Employee.Name]))
                        {
                            IsUpdated = true;
                            oldt.Name = Convert.ToString(obj[Employee.Name]);
                        }
                        if (oldt.PostCode != Convert.ToString(obj[Employee.PostCode]))
                        {
                            IsUpdated = true;
                            oldt.PostCode = Convert.ToString(obj[Employee.PostCode]);
                        }
                        if (oldt.PostOffice != Convert.ToString(obj[Employee.PostOffice]))
                        {
                            IsUpdated = true;
                            oldt.PostOffice = Convert.ToString(obj[Employee.PostOffice]);
                        }
                        if (oldt.Telefax != Convert.ToString(obj[Employee.Telefax]))
                        {
                            IsUpdated = true;
                            oldt.Telefax = Convert.ToString(obj[Employee.Telefax]);
                        }
                        if (oldt.PostAccount != Convert.ToString(obj[Employee.PostAccount]))
                        {
                            IsUpdated = true;
                            oldt.PostAccount = Convert.ToString(obj[Employee.PostAccount]);
                        }
                        if (oldt.BankAccount != Convert.ToString(obj[Employee.BankAccount]))
                        {
                            IsUpdated = true;
                            oldt.BankAccount = Convert.ToString(obj[Employee.BankAccount]);
                        }
                        if (oldt.CountryNo != Convert.ToInt32(obj[Employee.CountryNo]))
                        {
                            IsUpdated = true;
                            oldt.CountryNo = Convert.ToInt32(obj[Employee.CountryNo]);
                        }
                        if (oldt.Address1 != Convert.ToString(obj[Employee.Address1]))
                        {
                            IsUpdated = true;
                            oldt.Address1 = Convert.ToString(obj[Employee.Address1]);
                        }
                        if (oldt.EmployeeNo != Convert.ToInt32(obj[Employee.EmployeeNo]))
                        {
                            IsUpdated = true;
                            oldt.EmployeeNo = Convert.ToInt32(obj[Employee.EmployeeNo]);
                        }
                        if (oldt.WareHouseNo != Convert.ToInt32(obj[Employee.WareHouseNo]))
                        {
                            IsUpdated = true;
                            oldt.WareHouseNo = Convert.ToInt32(obj[Employee.WareHouseNo]);
                        }
                        if (oldt.InActiveYesNo != Convert.ToBoolean(obj[Employee.InActiveYesNo]))
                        {
                            IsUpdated = true;
                            oldt.InActiveYesNo = Convert.ToBoolean(obj[Employee.InActiveYesNo]);
                        }
                        if (oldt.Password != Convert.ToString(obj[Employee.Password]))
                        {
                            IsUpdated = true;
                            oldt.Password = Convert.ToString(obj[Employee.Password]);
                        }
                        if (oldt.ProjectNo != Convert.ToInt32(obj[Employee.ProjectNo]))
                        {
                            IsUpdated = true;
                            oldt.ProjectNo = Convert.ToInt32(obj[Employee.ProjectNo]);
                        }
                        if (oldt.DepNo != Convert.ToInt32(obj[Employee.DepNo]))
                        {
                            IsUpdated = true;
                            oldt.DepNo = Convert.ToInt32(obj[Employee.DepNo]);
                        }
                        if (oldt.Address3 != Convert.ToString(obj[Employee.Address3]))
                        {
                            IsUpdated = true;
                            oldt.Address3 = Convert.ToString(obj[Employee.Address3]);
                        }
                        if (oldt.Address2 != Convert.ToString(obj[Employee.Address2]))
                        {
                            IsUpdated = true;
                            oldt.Address2 = Convert.ToString(obj[Employee.Address2]);
                        }
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[Employee.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[Employee.LastUpdate]);
                        }
                        if (oldt.EbusinessType != Convert.ToInt32(obj[Employee.EbusinessType]))
                        {
                            IsUpdated = true;
                            oldt.EbusinessType = Convert.ToInt32(obj[Employee.EbusinessType]);
                        }
                        if (oldt.Titel != Convert.ToString(obj[Employee.Titel]))
                        {
                            IsUpdated = true;
                            oldt.Titel = Convert.ToString(obj[Employee.Titel]);
                        }
                        if (oldt.InternalTelephone != Convert.ToString(obj[Employee.InternalTelephone]))
                        {
                            IsUpdated = true;
                            oldt.InternalTelephone = Convert.ToString(obj[Employee.InternalTelephone]);
                        }
                        if (oldt.MobileTelephone != Convert.ToString(obj[Employee.MobileTelephone]))
                        {
                            IsUpdated = true;
                            oldt.MobileTelephone = Convert.ToString(obj[Employee.MobileTelephone]);
                        }
                        if (oldt.CommissionNo != Convert.ToInt32(obj[Employee.CommissionNo]))
                        {
                            IsUpdated = true;
                            oldt.CommissionNo = Convert.ToInt32(obj[Employee.CommissionNo]);
                        }
                        if (oldt.PrivateTelephone != Convert.ToString(obj[Employee.PrivateTelephone]))
                        {
                            IsUpdated = true;
                            oldt.PrivateTelephone = Convert.ToString(obj[Employee.PrivateTelephone]);
                        }
                        if (oldt.HireDate != Convert.ToDateTime(obj[Employee.HireDate]))
                        {
                            IsUpdated = true;
                            oldt.HireDate = Convert.ToDateTime(obj[Employee.HireDate]);
                        }
                        if (oldt.ReportsTo != Convert.ToInt32(obj[Employee.ReportsTo]))
                        {
                            IsUpdated = true;
                            oldt.ReportsTo = Convert.ToInt32(obj[Employee.ReportsTo]);
                        }
                        if (oldt.NameReportsTo != Convert.ToString(obj[Employee.NameReportsTo]))
                        {
                            IsUpdated = true;
                            oldt.NameReportsTo = Convert.ToString(obj[Employee.NameReportsTo]);
                        }
                        if (oldt.InternalEmailAddress != Convert.ToString(obj[Employee.InternalEmailAddress]))
                        {
                            IsUpdated = true;
                            oldt.InternalEmailAddress = Convert.ToString(obj[Employee.InternalEmailAddress]);
                        }
                        if (oldt.PrivateEmailAddress != Convert.ToString(obj[Employee.PrivateEmailAddress]))
                        {
                            IsUpdated = true;
                            oldt.PrivateEmailAddress = Convert.ToString(obj[Employee.PrivateEmailAddress]);
                        }
                        if (oldt.ProductNo != Convert.ToInt32(obj[Employee.ProductNo]))
                        {
                            IsUpdated = true;
                            oldt.ProductNo = Convert.ToInt32(obj[Employee.ProductNo]);
                        }
                        if (oldt.NickName != Convert.ToString(obj[Employee.NickName]))
                        {
                            IsUpdated = true;
                            oldt.NickName = Convert.ToString(obj[Employee.NickName]);
                        }
                        if (oldt.BusyReason != Convert.ToString(obj[Employee.BusyReason]))
                        {
                            IsUpdated = true;
                            oldt.BusyReason = Convert.ToString(obj[Employee.BusyReason]);
                        }
                        if (oldt.BusyStatus != Convert.ToBoolean(obj[Employee.BusyStatus]))
                        {
                            IsUpdated = true;
                            oldt.BusyStatus = Convert.ToBoolean(obj[Employee.BusyStatus]);
                        }
                        if (oldt.EndedDate != Convert.ToDateTime(obj[Employee.EndedDate]))
                        {
                            IsUpdated = true;
                            oldt.EndedDate = Convert.ToDateTime(obj[Employee.EndedDate]);
                        }
                        if (oldt.Sex != Convert.ToInt32(obj[Employee.Sex]))
                        {
                            IsUpdated = true;
                            oldt.Sex = Convert.ToInt32(obj[Employee.Sex]);
                        }
                        if (oldt.Bleeper != Convert.ToString(obj[Employee.Bleeper]))
                        {
                            IsUpdated = true;
                            oldt.Bleeper = Convert.ToString(obj[Employee.Bleeper]);
                        }
                        if (oldt.PersonalWWWAddress != Convert.ToString(obj[Employee.PersonalWWWAddress]))
                        {
                            IsUpdated = true;
                            oldt.PersonalWWWAddress = Convert.ToString(obj[Employee.PersonalWWWAddress]);
                        }
                        if (oldt.UserNo != Convert.ToInt32(obj[Employee.UserNo]))
                        {
                            IsUpdated = true;
                            oldt.UserNo = Convert.ToInt32(obj[Employee.UserNo]);
                        }
                        if (oldt.Birthday != Convert.ToString(obj[Employee.Birthday]))
                        {
                            IsUpdated = true;
                            oldt.Birthday = Convert.ToString(obj[Employee.Birthday]);
                        }
                        if (oldt.MiddleName != Convert.ToString(obj[Employee.MiddleName]))
                        {
                            IsUpdated = true;
                            oldt.MiddleName = Convert.ToString(obj[Employee.MiddleName]);
                        }
                        if (oldt.FamilyName != Convert.ToString(obj[Employee.FamilyName]))
                        {
                            IsUpdated = true;
                            oldt.FamilyName = Convert.ToString(obj[Employee.FamilyName]);
                        }
                        if (oldt.ParentFamilyName != Convert.ToString(obj[Employee.ParentFamilyName]))
                        {
                            IsUpdated = true;
                            oldt.ParentFamilyName = Convert.ToString(obj[Employee.ParentFamilyName]);
                        }
                        if (oldt.ParentName != Convert.ToString(obj[Employee.ParentName]))
                        {
                            IsUpdated = true;
                            oldt.ParentName = Convert.ToString(obj[Employee.ParentName]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[Employee.LastUpdatedBy]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[Employee.LastUpdatedBy]);
                        }
                        if (oldt.Created != Convert.ToDateTime(obj[Employee.Created]))
                        {
                            IsUpdated = true;
                            oldt.Created = Convert.ToDateTime(obj[Employee.Created]);
                        }
                        if (oldt.CreatedBy != Convert.ToInt32(obj[Employee.CreatedBy]))
                        {
                            IsUpdated = true;
                            oldt.CreatedBy = Convert.ToInt32(obj[Employee.CreatedBy]);
                        }
                        if (oldt.PLUser != Convert.ToInt32(obj[Employee.PLUser]))
                        {
                            IsUpdated = true;
                            oldt.PLUser = Convert.ToInt32(obj[Employee.PLUser]);
                        }
                        if (oldt.DeviationControlYesNo != Convert.ToBoolean(obj[Employee.DeviationControlYesNo]))
                        {
                            IsUpdated = true;
                            oldt.DeviationControlYesNo = Convert.ToBoolean(obj[Employee.DeviationControlYesNo]);
                        }
                        if (oldt.SubstManagerYesNo != Convert.ToBoolean(obj[Employee.SubstManagerYesNo]))
                        {
                            IsUpdated = true;
                            oldt.SubstManagerYesNo = Convert.ToBoolean(obj[Employee.SubstManagerYesNo]);
                        }
                        if (oldt.EmployeeCatNo != Convert.ToInt32(obj[Employee.EmployeeCatNo]))
                        {
                            IsUpdated = true;
                            oldt.EmployeeCatNo = Convert.ToInt32(obj[Employee.EmployeeCatNo]);
                        }
                        if (oldt.TimeCostPrice != Convert.ToInt32(obj[Employee.TimeCostPrice]))
                        {
                            IsUpdated = true;
                            oldt.TimeCostPrice = Convert.ToInt32(obj[Employee.TimeCostPrice]);
                        }
                        if (oldt.TimeSalesPrice != Convert.ToInt32(obj[Employee.TimeSalesPrice]))
                        {
                            IsUpdated = true;
                            oldt.TimeSalesPrice = Convert.ToInt32(obj[Employee.TimeSalesPrice]);
                        }
                        if (oldt.WorkingHours != Convert.ToInt32(obj[Employee.WorkingHours]))
                        {
                            IsUpdated = true;
                            oldt.WorkingHours = Convert.ToInt32(obj[Employee.WorkingHours]);
                        }
                        if (oldt.AllowTimeSheetRegAllUsers != Convert.ToBoolean(obj[Employee.AllowTimeSheetRegAllUsers]))
                        {
                            IsUpdated = true;
                            oldt.AllowTimeSheetRegAllUsers = Convert.ToBoolean(obj[Employee.AllowTimeSheetRegAllUsers]);
                        }
                        if (oldt.UseWagesortYesNo != Convert.ToInt32(obj[Employee.UseWagesortYesNo]))
                        {
                            IsUpdated = true;
                            oldt.UseWagesortYesNo = Convert.ToInt32(obj[Employee.UseWagesortYesNo]);
                        }
                        if (oldt.TimeWgSrtNo != Convert.ToInt32(obj[Employee.TimeWgSrtNo]))
                        {
                            IsUpdated = true;
                            oldt.TimeWgSrtNo = Convert.ToInt32(obj[Employee.TimeWgSrtNo]);
                        }
                        if (oldt.DeputyNo != Convert.ToInt32(obj[Employee.DeputyNo]))
                        {
                            IsUpdated = true;
                            oldt.DeputyNo = Convert.ToInt32(obj[Employee.DeputyNo]);
                        }
                        if (oldt.MaxAttestationAmount != Convert.ToInt32(obj[Employee.MaxAttestationAmount]))
                        {
                            IsUpdated = true;
                            oldt.MaxAttestationAmount = Convert.ToInt32(obj[Employee.MaxAttestationAmount]);
                        }
                        if (oldt.SuperiorNo != Convert.ToInt32(obj[Employee.SuperiorNo]))
                        {
                            IsUpdated = true;
                            oldt.SuperiorNo = Convert.ToInt32(obj[Employee.SuperiorNo]);
                        }
                        if (IsUpdated)
                        {
                            oldt.IsUpdated = IsUpdated;
                            DB.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void UpdateEmployee()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vEmployees = DB.vEmployees.Where(u => u.IsUpdated == true).ToList();
                    foreach (var v in vEmployees)
                    {
                        try
                        {
                            var t = DB.tblEmployees.Where(u => u.EmployeeNo == v.EmployeeNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {
                                    t = new Admin.DBLayer.tblEmployee();
                                    t.Address1 = v.Address1;
                                    t.Address2 = v.Address2;
                                    t.Address3 = v.Address3; 
                                    t.BankAccount = v.BankAccount;
                                    t.CreateBy = "VISMA";
                                    t.CountryId = new Guid("2A8B3E38-7D7F-4A43-B38B-1CC19FB2D144");
                                    t.CreationDate = DateTime.Now;
                                    t.DisplayOrder = v.EmployeeNo;
                                    t.Email = v.InternalEmailAddress;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.PostOffice = v.PostOffice;
                                    t.PostAccount = v.PostAccount;
                                    t.StatusId = v.InActiveYesNo==true ? new Guid(Utilities.Status_Active) : new Guid(Utilities.Status_InActive);
                                    t.EmployeeId = Guid.NewGuid();
                                    t.EmployeeNo = v.EmployeeNo;
                                    t.FamilyName = v.FamilyName;
                                    t.HireDate = v.HireDate;
                                    t.InternalTelephone = v.InternalTelephone;
                                    t.MiddleName = v.MiddleName;
                                    t.MobileTelephone = v.MobileTelephone;
                                    t.NickName = v.NickName;
                                    t.PostCode = v.PostCode;
                                    t.ReportsToId = Guid.Empty;
                                    t.Sex = v.Sex;
                                    t.Title = v.Titel;      
                                    DB2.tblEmployees.Add(t);
                                    DB2.SaveChanges();
                                }
                                else
                                {
                                    t.ModifyBy = "VISMA";
                                    t.ModifyDate = DateTime.Now;
                                    t.Address1 = v.Address1;
                                    t.Address2 = v.Address2;
                                    t.Address3 = v.Address3;
                                    t.BankAccount = v.BankAccount;
                                    t.CountryId = new Guid("2A8B3E38-7D7F-4A43-B38B-1CC19FB2D144");
                                    t.DisplayOrder = v.EmployeeNo;
                                    t.Email = v.InternalEmailAddress;
                                    t.IsVISMA = true;
                                    t.Name = v.Name;
                                    t.PostOffice = v.PostOffice;
                                    t.PostAccount = v.PostAccount;
                                    t.StatusId = v.InActiveYesNo == true ? new Guid(Utilities.Status_Active) : new Guid(Utilities.Status_InActive);
                                    t.EmployeeId = Guid.NewGuid();
                                    t.EmployeeNo = v.EmployeeNo;
                                    t.FamilyName = v.FamilyName;
                                    t.HireDate = v.HireDate;
                                    t.InternalTelephone = v.InternalTelephone;
                                    t.MiddleName = v.MiddleName;
                                    t.MobileTelephone = v.MobileTelephone;
                                    t.NickName = v.NickName;
                                    t.PostCode = v.PostCode;
                                    t.ReportsToId = Guid.Empty;
                                    t.Sex = v.Sex;
                                    t.Title = v.Titel;
                                    DB2.SaveChanges();
                                }
                            }
                            v.IsUpdated = false;
                            DB.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}

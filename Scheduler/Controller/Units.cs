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
    class Units
    {
        private const string URL = Utilities.URL + "units";
        private string urlParameters = "";
        public async Task GetUnits()
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
                    if (!(json[Unit.ARRAY_UNITS] is JArray)) return;
                    var col = (JArray)json[Unit.ARRAY_UNITS];
                    foreach (JObject obj in col)
                    {
                        this.AddUnit(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void AddUnit(JObject obj)
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var UnitNo = Convert.ToInt32(obj[Unit.UnitNo]);
                    var oldt = DB.vUnits.Where(u => u.UnitNo ==  UnitNo).FirstOrDefault();
                    if (oldt == null)
                    {
                        var t = new Admin.DBLayer.vUnit();
                        t.LastUpdate = Convert.ToDateTime(obj[Unit.LastUpdate]);
                        t.LastUpdatedBy = Convert.ToInt32(obj[Unit.LastUpdatedBy]);
                        t.Created = Convert.ToDateTime(obj[Unit.Created]);
                        t.CreatedBy = Convert.ToInt32(obj[Unit.CreatedBy]);
                        t.UnitNo = Convert.ToInt32(obj[Unit.UnitNo]);
                        t.UnitName = Convert.ToString(obj[Unit.UnitName]);
                        t.EDIName = Convert.ToString(obj[Unit.EDIName]);
                        t.IsUpdated = true;
                        DB.vUnits.Add(t);
                        DB.SaveChanges();
                    }
                    else
                    {
                        bool IsUpdated = false;
                        if (oldt.LastUpdate != Convert.ToDateTime(obj[Unit.LastUpdate]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdate = Convert.ToDateTime(obj[Unit.LastUpdate]);
                        }
                        if (oldt.LastUpdatedBy != Convert.ToInt32(obj[Unit.LastUpdatedBy]))
                        {
                            IsUpdated = true;
                            oldt.LastUpdatedBy = Convert.ToInt32(obj[Unit.LastUpdatedBy]);
                        }
                        if (oldt.Created != Convert.ToDateTime(obj[Unit.Created]))
                        {
                            IsUpdated = true;
                            oldt.Created = Convert.ToDateTime(obj[Unit.Created]);
                        }
                        if (oldt.CreatedBy != Convert.ToInt32(obj[Unit.CreatedBy]))
                        {
                            IsUpdated = true;
                            oldt.CreatedBy = Convert.ToInt32(obj[Unit.CreatedBy]);
                        }
                        if (oldt.UnitNo != Convert.ToInt32(obj[Unit.UnitNo]))
                        {
                            IsUpdated = true;
                            oldt.UnitNo = Convert.ToInt32(obj[Unit.UnitNo]);
                        }
                        if (oldt.UnitName != Convert.ToString(obj[Unit.UnitName]))
                        {
                            IsUpdated = true;
                            oldt.UnitName = Convert.ToString(obj[Unit.UnitName]);
                        }
                        if (oldt.EDIName != Convert.ToString(obj[Unit.EDIName]))
                        {
                            IsUpdated = true;
                            oldt.EDIName = Convert.ToString(obj[Unit.EDIName]);
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

        public void UpdateUnit()
        {
            try
            {
                using (Admin.DBLayer.ICONEntities2 DB = new Admin.DBLayer.ICONEntities2())
                {
                    var vUnits = DB.vUnits.Where(u => u.IsUpdated == true).ToList();
                    foreach (var v in vUnits)
                    {
                        try
                        {
                            var t = DB.tblUnits.Where(u => u.UnitNo == v.UnitNo).FirstOrDefault();
                            using (Admin.DBLayer.ICONEntities2 DB2 = new Admin.DBLayer.ICONEntities2())
                            {
                                if (t == null)
                                {
                                    t = new Admin.DBLayer.tblUnit();
                                    t.UnitId = Guid.NewGuid();
                                    t.DisplayOrder = v.UnitNo;
                                    t.EDIName  = v.EDIName;
                                    t.Name  = v.UnitName;
                                    t.CreateBy = "VISMA";
                                    t.CreationDate = DateTime.Now;
                                    t.IsVISMA = true;
                                    t.StatusId = new Guid(Utilities.Status_Active);
                                    t.UnitNo = v.UnitNo;
                                    DB2.tblUnits.Add(t);
                                    DB2.SaveChanges();
                                }
                                else
                                {
                                    t.DisplayOrder = v.UnitNo;
                                    t.EDIName = v.EDIName;
                                    t.Name = v.UnitName;
                                    t.ModifyBy = "VISMA";
                                    t.ModifyDate = DateTime.Now;
                                    t.IsVISMA = true;
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

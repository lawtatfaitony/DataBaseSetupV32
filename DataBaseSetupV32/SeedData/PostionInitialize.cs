using AttendanceBussiness.DbFirst;
using DataBaseSetupV3.SeedData;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DataBaseSetupV3
{
    public static class PostionInitialize
    {
        private static string MainComId = SystemData.CreateMainComId();
        private static DataBaseContext context = Configurations.GetDataBaseContext();
        public static void PostionInitializeSeedData()
        {
            #region  Initialize seed data
            string mainComId = SystemData.CreateMainComId();
            string IndustryId = SystemData.GetIndustryId();
            if (IndustryId == "IN60006")
            {
                    var postionIns = new List<Position>
                    {
                         new Position{ PositionId =$"{mainComId}001" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Sub-con Worker", EnPositionTitle ="Sub-con Worker" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}002" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Sub-con Management	", EnPositionTitle ="Sub-con Management	" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}003" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Site Agent", EnPositionTitle ="Site Agent" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}004" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Project Quantity Surveyor", EnPositionTitle ="Project Quantity Surveyor" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}005" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Assistant Planning Manager", EnPositionTitle ="Assistant Planning Manager" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}006" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Graduate Engineer", EnPositionTitle ="Graduate Engineer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}007" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Graduate Engineer", EnPositionTitle ="Graduate Engineer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}008" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Foreman", EnPositionTitle ="Foreman" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}009" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Site Clerk", EnPositionTitle ="Site Clerk" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}010" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Worker", EnPositionTitle ="Worker" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}011" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Rigger", EnPositionTitle ="Rigger" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}012" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Assistance Quantity Surveyor", EnPositionTitle ="Assistance Quantity Surveyor" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}013" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Safety Officer", EnPositionTitle ="Safety Officer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}014" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Amah", EnPositionTitle ="Amah" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}015" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Concretor", EnPositionTitle ="Concretor" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}016" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Electrical Fitter", EnPositionTitle ="Electrical Fitter" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}017" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Assistant Construction Manager", EnPositionTitle ="Assistant Construction Manager" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}018" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Project Manager", EnPositionTitle ="Project Manager" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}019" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Admin Officer", EnPositionTitle ="Admin Officer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}020" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Engineer", EnPositionTitle ="Engineer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}021" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Surveyor 測量員	", EnPositionTitle ="	Surveyor 測量員	" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}022" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Asst.Suveyor 助理測量員	", EnPositionTitle ="Asst.Suveyor 助理測量員" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}023" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Driver 司機", EnPositionTitle ="Driver 司機" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}024" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="SRE", EnPositionTitle ="SRE" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}025" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="IOW", EnPositionTitle ="IOW" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}026" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="WE(II)", EnPositionTitle ="WE(II)" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}027" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="ACO", EnPositionTitle ="ACO" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}028" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Security Guard保安員", EnPositionTitle ="Security Guard保安員" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}029" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Asst.General Manager", EnPositionTitle ="Asst.General Manager" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}030" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Senior Surveying Manager", EnPositionTitle ="Senior Surveying Manager" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}031" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="TECH", EnPositionTitle ="TECH" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}032" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Senior BIM Officer", EnPositionTitle ="Senior BIM Officer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}033" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Asst.BIM Co-ordinator", EnPositionTitle ="Asst.BIM Co-ordinator" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}034" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Assistant Project Manager", EnPositionTitle ="Assistant Project Manager" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}035" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Assistant BS Engineer", EnPositionTitle ="Assistant BS Engineer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}036" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="QS Clerk", EnPositionTitle ="	QS Clerk" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}037" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Senior BIM Techinican", EnPositionTitle ="Senior BIM Techinican" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}038" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="enior Building Service Engineern", EnPositionTitle ="enior Building Service Engineer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}038" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="	Asst.Safety Officer", EnPositionTitle ="Asst.Safety Officer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}039" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="enior Building Service Engineern", EnPositionTitle ="enior Building Service Engineer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}040" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="BS Engineer", EnPositionTitle ="BS Engineer" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}041" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Senior Draftsman", EnPositionTitle ="Senior Draftsman" ,CreatedDate = DateTime.Now,MainComId = MainComId},
                         new Position{ PositionId =$"{mainComId}042" ,IndustryId="IN60006", IndustryName =LangAuto.Auto("建造業"), PositionTitle ="Site Administration Officer", EnPositionTitle ="Site Administration Officer" ,CreatedDate = DateTime.Now,MainComId = MainComId}
                    };
                    postionIns.ForEach(a =>
                    {
                        if (context.Position.Find(a.PositionId) == null)
                        {
                            try
                            {
                                context.Position.Add(a);
                                Console.WriteLine(string.Format("SUCCESS : {0} - {1} - {2} - {3} - {4}", a.PositionId, a.IndustryId, a.IndustryName, a.PositionTitle, a.EnPositionTitle, a.CreatedDate));
                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex.Message);
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine(string.Format("EXISTS :  {0} - {1} - {2} - {3} - {4}", a.PositionId, a.IndustryId, a.IndustryName, a.PositionTitle, a.EnPositionTitle, a.CreatedDate));
                        }
                        int delay = 100;
    #if DEBUG
                        delay = 50;
    #endif
                        Thread.Sleep(delay);
                    }); //Position
                    context.SaveChanges();
            }
            else //其他则输入默认 OtherWise Enter default value
            {
                var industry = context.Industry.Find(IndustryId);
                var position = new Position { PositionId = $"{mainComId}001", IndustryId = IndustryId, IndustryName = industry?.IndustryName ?? string.Empty, PositionTitle = "WORK POSITION 01", EnPositionTitle = "Position Title 1", CreatedDate = DateTime.Now, MainComId = MainComId };
                 
                context.Position.Add(position);
                bool res = context.SaveChanges() > 0;
                if (res)
                {
                    Console.WriteLine(string.Format("[SUCCESS][POSITION ADD] : {0} {1} {2} {3} {4}", position.PositionId, position.PositionTitle, position.EnPositionTitle, position.IndustryName, position.MainComId));
                }
                else
                {
                    Console.WriteLine(string.Format("[FAIL] [POSITION ADD] : {0} {1} {2} {3} {4}", position.PositionId, position.PositionTitle, position.EnPositionTitle, position.IndustryName, position.MainComId));
                }
            }
            #endregion
        }
    }
}
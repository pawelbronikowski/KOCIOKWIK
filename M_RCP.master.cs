using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    bibl_rcp bk = new bibl_rcp();
    IfxDataBaserc db = new IfxDataBaserc();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["nrst"] = "0";
        //Response.Charset = "iso-8859-2";  
        TextBox1.Text = bk.rok_bazy();
    }

    protected void LinkIFK_Click(object sender, EventArgs e)
    {
        Response.Write("<script language = 'Javascript'>window.open('http://www.ifk.com.pl/1poczatek/poczatek.php')</script>");
    }
    protected void MailIFK_Click(object sender, MenuEventArgs e) { }

    public void MenuItemClick(object sender, MenuEventArgs e)
    {
        string p_uzytkow = (string)Session["uzytkownik"];
        //    int st_upr = bk.uprawnienia(p_uzytkow);
        DataView view = (DataView)Session["pracownicy"];
        string wartosc = e.Item.Value.ToString();
        switch (wartosc)
        {
            /*
  druki             
druki_nag         
harmon            
nadg              
plan_dyzur        
rcp_blokady       
rcp_drukarki      
rcp_filtry        
rcp_grafik        
rcp_grafik_o      
rcp_kod_plac      
rcp_person        
rcp_pobyty        
rcp_premia        
rcp_rejestracje   
rcp_sl_gp         
rcp_sl_gr_wej     
rcp_sl_grafik     
rcp_sl_kody       
rcp_sl_oddz       
rcp_sl_plac       
rcp_sl_zmian      
rcp_swieta        
rcp_transdysk     
rcp_uzytkown      
rcp_wejsc_inne    
rcp_wymiary       
soc_slow          
socjalne          
t_menu_dr         
t_menu_g          
test_wejsc        
uprawn            
wej_spec          
*/
            case "Firma":
                Session["uniwersalny_opis"] = " Dane Firmy ";
                Session["uniwersalny_tablica"] = "rcp_firma";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Użytkownicy":
                Session["uniwersalny_opis"] = " UŻYTKOWNICY I UPRAWNIENIA ";
                Session["uniwersalny_tablica"] = "rcp_uzytkown";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Filtry":
                Session["uniwersalny_opis"] = " FILTRY UŻYTKOWNIKÓW ";
                Session["uniwersalny_tablica"] = "rcp_filtry";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Blokady":
                string strSql = "select * from rcp_blokady";
                Session["blokady"] = strSql;
                Response.Write("<script language = 'Javascript'>window.open('../blokady.aspx')</script>");
                break;
            case "sl_grafik":
                Session["uniwersalny_opis"] = " SLOWNIKI GRAFIKÓW ";
                Session["uniwersalny_tablica"] = "rcp_sl_grafik";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Person":
                Session["uniwersalny_opis"] = " Kartoteka PERSONALNA ";
                Session["uniwersalny_tablica"] = "rcp_person";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Wymiary":
                Session["uniwersalny_opis"] = " WYMIARY Uropów i NCP ";
                Session["uniwersalny_tablica"] = "rcp_wymiary";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Pobyty":
                Session["uniwersalny_opis"] = " POBYTY - bez filtrów ";
                Session["uniwersalny_tablica"] = "rcp_pobyty";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Rejestracje":
                Session["uniwersalny_opis"] = " Rejestracje z czytników ";
                Session["uniwersalny_tablica"] = "rcp_rejestracje";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Grafiki":
                Session["uniwersalny_opis"] = " GRAFIKI - Tablica ";
                Session["uniwersalny_tablica"] = "rcp_grafik";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Oddziały":
                Session["uniwersalny_opis"] = " ODDZIAŁY - Słownik RCP ";
                Session["uniwersalny_tablica"] = "rcp_oddzialy";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Grupy Wejść":
                Session["uniwersalny_opis"] = " BLOKADY RCP ";
                Session["uniwersalny_tablica"] = "rcp_blokady";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Kody":
                Session["uniwersalny_opis"] = " KODY RCP ";
                Session["uniwersalny_tablica"] = "rcp_sl_kod";
                Response.Redirect("uniwersalny.aspx");
                break;

            /*case "Nadgodziny":
                Session["uniwersalny_opis"] = " Nadgodziny na koniec miesiąca ";
                Session["uniwersalny_tablica"] = "rcp_nadgodz";
                Response.Redirect("uniwersalny.aspx");
                break;*/




            case "Drukarki":
                Session["uniwersalny_opis"] = " DRUKARKI ";
                Session["uniwersalny_tablica"] = "rcp_drukarki";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Premie":
                Session["uniwersalny_opis"] = " Premie ";
                Session["uniwersalny_tablica"] = "rcp_premie";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Place":
                Session["uniwersalny_opis"] = " KODY EXPORTU DO PŁAC ";
                Session["uniwersalny_tablica"] = "rcp_place";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Transdysk":
                Session["uniwersalny_opis"] = " Transdysk - przelewy ";
                Session["uniwersalny_tablica"] = "rcp_transdysk";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Wejścia Specjalne":
                Session["uniwersalny_opis"] = " Wejścia Specjalne ";
                Session["uniwersalny_tablica"] = "rcp_wej_spec";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "R&#243;wnoważniki GP":
                Session["uniwersalny_opis"] = " RÓWNOWAZNIKI KODÓW RCP I GRAFIKÓW";
                Session["uniwersalny_tablica"] = "rcp_rownowaz";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Zmiany":
                Session["uniwersalny_opis"] = " Zmiany - czasy pracy w RCP ";
                Session["uniwersalny_tablica"] = "rcp_sl_zmian";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Socjalne":
                Session["uniwersalny_opis"] = " SOCJALNE RCP ";
                Session["uniwersalny_tablica"] = "socjalne";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Śwęta":
                Session["uniwersalny_opis"] = " ŚWIĘTA w ROKU";
                Session["uniwersalny_tablica"] = "rcp_swieta";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Menu_g":
                Session["uniwersalny_opis"] = " Menu GŁÓWNE UŻYTKOWNIKA ";
                Session["uniwersalny_tablica"] = "rcp_menu_g";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Menu_d":
                Session["uniwersalny_opis"] = " Menu Druków RCP ";
                Session["uniwersalny_tablica"] = "rcp_menu_d";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "ZAPAS":
                Session["uniwersalny_opis"] = " ZAPAS RCP ";
                Session["uniwersalny_tablica"] = "rcp_blokady";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "ETC":
                Session["uniwersalny_opis"] = " ETC RCP ";
                Session["uniwersalny_tablica"] = "rcp_blokady";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Kody Oddz":
                Session["uniwersalny_opis"] = " SŁOWNIK GRAFIKÓW ODDZ ";
                Session["uniwersalny_tablica"] = "rcp_sl_grafik";
                Response.Redirect("uniwersalny.aspx");
                break;
            case "Ustawienia":
                //string ustawienia = System.Configuration.ConfigurationSettings.AppSettings.Get("SqlConnectionStringkpk");
                string ustawienia = db.konekt_sys();
                int haslo = ustawienia.IndexOf("Password");
                ustawienia = ustawienia.Substring(0, haslo);
                string kataloghasel = System.Configuration.ConfigurationSettings.AppSettings.Get("kataloghasel");
                string typ_bazy = System.Configuration.ConfigurationSettings.AppSettings.Get("typ_bazy");
                string HOST = System.Configuration.ConfigurationSettings.AppSettings.Get("ip_serwera_linux");
                //string DATABASE = Resources.Resource.baza_kpk;
                Session["komunikat1"] = "kompilacja 2011.08.11";
                Session["komunikat2"] = "serwer bazy danych : " + ustawienia;
                Session["komunikat3"] = "katalog skryptów ifk: " + kataloghasel;
                Session["komunikat4"] = "typ bazy danych      : " + typ_bazy;
                Session["komunikat2"] = "HOST     " + HOST;
                //Session["komunikat3"] = "DATABASE " + DATABASE;
                Response.Write("<script>window.open('Komunikat.aspx','_blank', 'width=686,height=200');</script>");
                break;
            case "Export":
                //Export znaczków i urlopów do SAGE Symfonia
                string filePath = "";
                string kol_nazw = "";
                DataView view_znaczki = new DataView(db.PerformSelect("SELECT nrst,nr_zn FROM rcp_person WHERE 1=1 "));
                try
                {
                    filePath = "/pisma/nr_karty_RCP.txt";
                    File.Delete(filePath);
                }
                catch
                {
                }
                FileStream fs_znaczki = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw_znaczki = new StreamWriter(fs_znaczki);
                for (int i = 0; i < view_znaczki.Count; i++)
                {
                    string wiersz = "";
                    for (int k = 0; k < view_znaczki.Table.Columns.Count; k++)
                    {
                        if (k == 0)
                        {
                            if (i == 0) { kol_nazw = "id prac"; }  //view.Table.Columns[k].ToString(); }
                            wiersz = view_znaczki.Table.Rows[i][k].ToString();
                        }
                        else
                        {
                            string pole = "";
                            string mkolumna = "";
                            string nazwakolumny = view_znaczki.Table.Columns[k].ToString();
                            mkolumna = nazwakolumny;
                            if (nazwakolumny == "nrst") { mkolumna = "id prac"; }
                            if (nazwakolumny == "nr_zn") { mkolumna = "nr karty RCP"; pole = view_znaczki.Table.Rows[i][k].ToString(); };
                            //if (nazwakolumny == "zwoln") { mkolumna = "Data do"; string s_data = viewumowaoprace.Table.Rows[i][k].ToString(); if (s_data.Length > 9) { pole = bk.zwrocdatecszarp(s_data); } }
                            //if (nazwakolumny == "data2") { mkolumna = "Data zawarcia umowy"; string s_data = viewumowaoprace.Table.Rows[i][k].ToString(); if (s_data.Length > 9) { pole = bk.zwrocdatecszarp(s_data); } }
                            if (i == 0) { kol_nazw = kol_nazw + "|" + mkolumna; }
                            wiersz = wiersz + "|" + pole;
                        }

                    }
                    if (i == 0)
                    {
                        sw_znaczki.WriteLine(kol_nazw);
                    }
                    wiersz = wiersz.Replace("00:00:00", "");
                    sw_znaczki.WriteLine(wiersz);
                }
                sw_znaczki.Close();
                // -----------------------------------                    NCP - "ślepe pola" do zapełnienia czymś innym
                DataView view_urlopy = new DataView(db.PerformSelect("SELECT nrst,urlop,urlop_z,urlop+urlop_z,ncp,ncp,ncp,ncp,ncp,ncp,ncp,ncp,ncp,ncp,ncp FROM rcp_person WHERE 1=1 ORDER BY 1 "));
                try
                {
                    filePath = "/pisma/STANY_ULOPOW.txt";
                    File.Delete(filePath);
                }
                catch
                {
                }
                FileStream fs_urlopy = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw_urlopy = new StreamWriter(fs_urlopy);
                for (int i = 0; i < view_urlopy.Count; i++)
                {
                    string wiersz = "";
                    string s_nrst = "";
                    decimal d_urlop = 0;
                    decimal d_urlopz = 0;
                    decimal d_urlopw = 0;
                    decimal d_urlopwz = 0;
                    decimal d_op = 0;
                    for (int k = 0; k < view_urlopy.Table.Columns.Count; k++)
                    {
                        if (k == 0)
                        {
                            if (i == 0) { kol_nazw = "id prac"; }  //view.Table.Columns[k].ToString(); }
                            wiersz = view_urlopy.Table.Rows[i][k].ToString();
                            s_nrst = view_urlopy.Table.Rows[i][k].ToString();
                        }
                        else
                        {
                            string pole = "";
                            string mkolumna = "";
                            string nazwakolumny = view_urlopy.Table.Columns[k].ToString();
                            mkolumna = nazwakolumny;
                            if (nazwakolumny == "nrst") { mkolumna = "id prac"; }
                            if (nazwakolumny == "urlop") { mkolumna = "wymiar urlopu przysługujący"; pole = view_urlopy.Table.Rows[i][k].ToString(); };
                            if (nazwakolumny == "urlop_z") { mkolumna = "wymiar urlopu zaległego"; pole = view_urlopy.Table.Rows[i][k].ToString(); try { d_urlopz = Convert.ToDecimal(view_urlopy.Table.Rows[i][k].ToString()); } catch { d_urlop = 0; }; }; //k =2
                            if (k == 3)
                            {
                                mkolumna = "urlop do wyk. w roku"; pole = view_urlopy.Table.Rows[i][k].ToString();
                                try { d_urlop = Convert.ToDecimal(view_urlopy.Table.Rows[i][k].ToString()); }
                                catch { d_urlop = 0; };
                            }
                            if (k == 4) { mkolumna = "urlop do wyk. w roku w godzinach"; pole = Convert.ToString(8 * d_urlop); }
                            if (k == 5) { mkolumna = "przysługuje na żądanie"; pole = "4"; }
                            if (k == 6) { mkolumna = "przysługuje dni opieki"; pole = ""; }
                            if (k == 7)
                            {
                                mkolumna = "zarejestrowane dni urlopu";
                                DataView view_url = new DataView(db.PerformSelect("SELECT count(*) FROM rcp_pobyty WHERE (kod = 'U' OR kod = 'Uz') AND nrst = " + s_nrst));
                                try { d_urlopw = Convert.ToDecimal(view_url.Table.Rows[0][0].ToString()); }
                                catch { d_urlopw = 0; };
                                pole = Convert.ToString(d_urlopw);
                            }
                            if (k == 8)
                            {
                                mkolumna = "wykorzystano na żądanie";
                                DataView view_url = new DataView(db.PerformSelect("SELECT count(*) FROM rcp_pobyty WHERE  kod = 'Uz' AND nrst = " + s_nrst));
                                try { d_urlopwz = Convert.ToDecimal(view_url.Table.Rows[0][0].ToString()); }
                                catch { d_urlopwz = 0; };
                                pole = Convert.ToString(d_urlopwz);
                            }
                            if (k == 9) { mkolumna = "zarejestrowane dni okolicznościowego"; pole = ""; }
                            if (k == 10)
                            {
                                mkolumna = "zarejestrowane dni opieki";
                                DataView view_op = new DataView(db.PerformSelect("SELECT count(*) FROM rcp_pobyty WHERE kod = 'P' AND nrst = " + s_nrst));
                                try { d_op = Convert.ToDecimal(view_op.Table.Rows[0][0].ToString()); }
                                catch { d_op = 0; };
                                pole = Convert.ToString(d_op);
                            }
                            if (k == 11) { mkolumna = "pozostało urlopu"; pole = Convert.ToString(d_urlop - d_urlopw); }
                            if (k == 12) { mkolumna = "pozostało godzin urlopu"; pole = Convert.ToString(8 * (d_urlop - d_urlopw)); }
                            if (k == 13) { mkolumna = "pozostało urlopu do zaplanowania"; pole = Convert.ToString(d_urlop - d_urlopw); }
                            if (k == 14)
                            {
                                mkolumna = "wykorzystano łącznie urlopu zaległego";
                                if (d_urlopz > d_urlopw) { pole = Convert.ToString(d_urlopz - d_urlopw); } else { pole = Convert.ToString(d_urlopz); };
                            }
                            //if (nazwakolumny == "data2") { mkolumna = "Data zawarcia umowy"; string s_data = viewumowaoprace.Table.Rows[i][k].ToString(); if (s_data.Length > 9) { pole = bk.zwrocdatecszarp(s_data); } }
                            if (i == 0) { kol_nazw = kol_nazw + "|" + mkolumna; }
                            wiersz = wiersz + "|" + pole;
                        }

                    }
                    if (i == 0)
                    {
                        sw_urlopy.WriteLine(kol_nazw);
                    }
                    wiersz = wiersz.Replace("00:00:00", "");
                    sw_urlopy.WriteLine(wiersz);
                }
                sw_znaczki.Close();



                Session["komunikat1"] = "kompilacja 2015.05.28";
                Session["komunikat2"] = "export poszedł  ";
                //Session["komunikat3"] = "katalog c:\pisma " ;
                Session["komunikat4"] = "pliki nr_karty_rcp   stany_urlopow ";
                //Session["komunikat2"] = "HOST     " + HOST;
                //Session["komunikat3"] = "DATABASE " + DATABASE;
                Response.Write("<script>window.open('Komunikat.aspx','_blank', 'width=686,height=200');</script>");
                break;
        }
    }

    public void zmodyfik_person(string p_nrst, string data_m, int x)
    {
        DataView view_modyf = (DataView)Session["wykazview"];
        string p_uzytkow = (string)Session["uzytkownik"];
        int i_nrst = Convert.ToInt32(p_nrst);
        if (i_nrst < 0)
        {
            DataTable dtujemny = db.PerformSelect("select * from person where nrst =" + i_nrst);
            string p_dasl = dtujemny.Rows[0]["dasl"].ToString();
            int roznicadm = bk.roznicadat(data_m, p_dasl);
            if (roznicadm < 0) { }
            else
            {
                string delete = ("delete from person where nrst =" + i_nrst);
                bool rezultatdel = db.PerformUpdate(delete);
                i_nrst = i_nrst * -1;
                DataTable dtdodatn = db.PerformSelect("select * from person where nrst =" + i_nrst);
                for (int p = 0; p < 100; p++)
                {
                    if (dtujemny.Rows[0][p].ToString() != dtdodatn.Rows[0][p].ToString())
                    {
                        string nazwapola = dtdodatn.Columns[p].ColumnName.ToString();
                        view_modyf.Table.Rows.Add(i_nrst, view_modyf.Table.Rows[x]["nazw"].ToString(), view_modyf.Table.Rows[x]["imie"].ToString(), "person", p, nazwapola, dtdodatn.Rows[0][p].ToString(), dtujemny.Rows[0][p].ToString());
                        if (nazwapola == "ostp")
                        {
                            string s_stans = "";
                            string s_ostpdodatni = "";
                            string s_ostpujemny = "";

                            try { s_stans = dtdodatn.Rows[0]["stans"].ToString(); }
                            catch { }
                            try { s_ostpdodatni = dtdodatn.Rows[0]["ostp"].ToString(); }
                            catch { }
                            try { s_ostpujemny = dtujemny.Rows[0]["ostp"].ToString(); }
                            catch { }
                            bk.spr_zatrudn(p_nrst, s_ostpdodatni, s_ostpujemny, s_stans);
                            view_modyf.Table.Rows.Add(i_nrst, view_modyf.Table.Rows[x]["nazw"].ToString(), view_modyf.Table.Rows[x]["imie"].ToString(), "teraz", p, dtujemny.Rows[0]["stans"], s_ostpdodatni, s_ostpujemny);
                        }
                    }
                }
                dtujemny.Rows[0]["nrst"] = i_nrst;
                delete = ("delete from person where nrst =" + i_nrst);
                rezultatdel = db.PerformUpdate(delete);
                bk.zapiszperson(data_m, p_uzytkow, dtujemny);
            }
        }
    }


    public decimal liczl(string data_m, string data_od, decimal zawartosc)
    {
        decimal zwrot = 0;
        int lata = 0;
        string sd1 = data_od.Substring(0, 2);
        string sd2 = data_m.Substring(0, 2);
        string sm1 = data_od.Substring(3, 2);
        string sm2 = data_m.Substring(3, 2);
        string sr1 = data_od.Substring(6, 4);
        string sr2 = data_m.Substring(6, 4);
        int d1 = Convert.ToInt16(sd1);
        int d2 = Convert.ToInt16(sd2);
        int m1 = Convert.ToInt16(sm1);
        int m2 = Convert.ToInt16(sm2);
        int r1 = Convert.ToInt16(sr1);
        int r2 = Convert.ToInt16(sr2);
        lata = r2 - r1;
        if (lata > 0)
        {
            if (m2 < m1)
            {
                if (d2 < d1) { lata = lata - 1; }
            }
        }
        zwrot = lata;
        zwrot = zwrot * zawartosc;
        return zwrot;
    }
}

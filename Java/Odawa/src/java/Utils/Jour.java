package Utils;

import java.text.DateFormatSymbols;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Locale;

public class Jour {

    public static ArrayList<String> getNomJours() {
        ArrayList<String> nmJ = new ArrayList();
        nmJ.add("Dimanche : ");
        nmJ.add("Lundi : ");
        nmJ.add("Mardi : ");
        nmJ.add("Mercredi : ");
        nmJ.add("Jeudi : ");
        nmJ.add("Vendredi : ");
        nmJ.add("Samedi : ");
        return nmJ;
    }
    
    public static String getNomJour() {
        DateFormatSymbols symbols = new DateFormatSymbols(Locale.FRENCH);
        return symbols.getWeekdays()[getNumJour()];
    }
    
    public static int getNumJour() {
        GregorianCalendar calendar = new GregorianCalendar();
        return calendar.get(Calendar.DAY_OF_WEEK);
    }
    
}

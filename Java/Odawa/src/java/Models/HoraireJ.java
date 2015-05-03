/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import java.sql.Time;

/**
 *
 * @author Denis Charette
 */
public class HoraireJ {
    private int id;
    private Time mondayOpen;
    private Time mondayClose;
    private Time tuesdayOpen;
    private Time tuesdayClose;
    private Time wednesdayOpen;
    private Time wednesdayClose;
    private Time thursdayOpen;
    private Time thursdayClose;
    private Time fridayOpen;
    private Time fridayClose;
    private Time saturdayOpen;
    private Time saturdayClose;
    private Time sundayOpen;
    private Time sundayClose;
    
    public void setId(int id) { this.id = id; }
    public void setMondayOpen(Time time) { this.mondayOpen = time; }
    public void setMondayClose(Time time) { this.mondayClose = time; }
    public void setTuesdayOpen(Time time) { this.tuesdayOpen = time; }
    public void setTuesdayClose(Time time) { this.tuesdayClose = time; }
    public void setWednesdayOpen(Time time) { this.wednesdayOpen = time; }
    public void setWednesdayClose(Time time) { this.wednesdayClose = time; }
    public void setThursdayOpen(Time time) { this.thursdayOpen = time; }
    public void setThursdayClose(Time time) { this.thursdayClose = time; }
    public void setFridayOpen(Time time) { this.fridayOpen = time; }
    public void setFridayClose(Time time) { this.fridayClose = time; }
    public void setSaturdayOpen(Time time) { this.saturdayOpen = time; }
    public void setSaturdayClose(Time time) { this.saturdayClose = time; }
    public void setSundayOpen(Time time) { this.sundayOpen = time; }
    public void setSundayClose(Time time) { this.sundayClose = time; }
    
    public int getId() { return this.id = id; }
    public Time getMondayOpen() { return this.mondayOpen; }
    public Time getMondayClose() { return this.mondayClose; }
    public Time getTuesdayOpen() { return this.tuesdayOpen; }
    public Time getTuesdayClose() { return this.tuesdayClose; }
    public Time getWednesdayOpen() { return this.wednesdayOpen; }
    public Time getWednesdayClose() { return this.wednesdayClose; }
    public Time getThursdayOpen() { return this.thursdayOpen; }
    public Time getThursdayClose() { return this.thursdayClose; }
    public Time getFridayOpen() { return this.fridayOpen; }
    public Time getFridayClose() { return this.fridayClose; }
    public Time getSaturdayOpen() { return this.saturdayOpen; }
    public Time getSaturdayClose() { return this.saturdayClose; }
    public Time getSundayOpen() { return this.sundayOpen; }
    public Time getSundayClose() { return this.sundayClose; }
}

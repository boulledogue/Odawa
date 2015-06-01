/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Utils;

import java.io.FileWriter;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author DCR
 */
public class LogManager {
    
    private Date date = new Date();
    
    public void LogException(Exception ex) {
        try
        {
            String filename = System.getProperty("java.io.tmpdir") + "JavaExceptionLog.log";
            FileWriter fw = new FileWriter(filename,true);
            fw.write(ex + "\n");
            fw.close();
        }
        catch(Exception e)
        {
            //on ne fait rien, erreur dans le log ne peut pas être bloquant
        }
    } 
    
    public void LogMailException(Exception ex) {
        try
        {            
            String filename = System.getProperty("java.io.tmpdir") + "JavaMailExceptionLog.log";
            FileWriter fw = new FileWriter(filename,true);
            fw.write(date + " --- " + ex + "\n");
            fw.close();
        }
        catch(Exception e)
        {
            //on ne fait rien, erreur dans le log ne peut pas être bloquant
        }
    }
    
    public void LogFormatException(Exception ex) {
        try
        {            
            String filename = System.getProperty("java.io.tmpdir") + "JavaFormatExceptionLog.log";
            FileWriter fw = new FileWriter(filename,true);
            fw.write(date + " --- " + ex + "\n");
            fw.close();
        }
        catch(Exception e)
        {
            //on ne fait rien, erreur dans le log ne peut pas être bloquant
        }
    }
}

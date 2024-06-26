/*

Windows version
tested on Windows11, VS 2022 preview

=== Nuget ===

install System.Management

=== end



=== the code ===

*/

 ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
 ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
 ManagementObjectCollection manObjCollection = searcher.Get();

 const string totalMemoryInKilobytesKey = "TotalVisibleMemorySize";
 
 foreach (ManagementObject manObj in manObjCollection)
 {

     PropertyDataCollection properties = manObj.Properties;

     foreach (PropertyData property in manObj.Properties)
     {
         Console.WriteLine("properties : " + property.Name + " , value : " + property.Value);
     }

 }

/*
=== end




=== the result ===
.
properties : BootDevice , value :
.
properties : CodeSet , value : 
properties : CountryCode , value : 
.
properties : CSName , value : 
properties : CurrentTimeZone , value : 
.
properties : FreePhysicalMemory , value : 46737904
properties : FreeSpaceInPagingFiles , value : 0
properties : FreeVirtualMemory , value : 42199368
.
properties : LocalDateTime , value : 
properties : Locale , value : 
.
properties : NumberOfProcesses , value : 287
.
properties : OSArchitecture , value : 64-bit
properties : OSLanguage , value : 
properties : OSProductSuite , value : 
properties : OSType , value : 18
.
properties : SystemDrive , value : C:
properties : TotalSwapSpaceSize , value :
properties : TotalVirtualMemorySize , value : 66374660
properties : TotalVisibleMemorySize , value : 66374660
.
.
.

=== end

*/

<?php
session_start();

//retrieve JOBID from homepage.php after having to click the update job button.
if(array_keys($_POST,"Update Job")!=NULL){
    $jobID_temp=array_keys($_POST,"Update Job");
    $jobID=$jobID_temp[0];
    $_SESSION['JobID'] = $jobID;
}
        //Connect to MYSQL database
        $servername = "localhost";
        $username = "root";
        $password = "";
        $db = "sdm";
        $connection = mysqli_connect($servername, $username, $password,$db);

        //Run query against database
        $query= "SELECT jobs.date,  jobs.JobID, client.ClientName, client.Address, client.PoolSize, jobs.EmpID, jobs.SupEmpID, jobs.SupEmpID2, jobs.JobStatus, jobs.Picture, jobs.JobRemarks
        FROM client INNER JOIN
        jobs ON client.ClientID = jobs.ClientID INNER JOIN
        employee ON jobs.EmpID = employee.EmpID OR jobs.SupEmpID = employee.EmpID OR jobs.SupEmpID2 = employee.EmpID
        WHERE (jobs.JobID = '$jobID')";
        $result=mysqli_query($connection, $query);

        //Store jobID details into variables to post details later on
        if (mysqli_num_rows($result) > 0) {
            while($row = mysqli_fetch_assoc($result)) {
                if ($row['JobID'] == $jobID ){
    
                    $date=$row['date'];
                    $ClientName=$row['ClientName'];
                    $Address=$row['Address'];
                    $PoolSize=$row['PoolSize'];
                    $EmpID=$row['EmpID'];
                    $SupEmpID=$row['SupEmpID'];
                    $SupEmpID2=$row['SupEmpID2'];
                    $JobStatus=$row['JobStatus'];
                    $Picture=$row['Picture'];
                    $JobRemarks=$row['JobRemarks'];
                }
            }
        }
?> 

<!DOCTYPE html>
<html>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>MCM Management System</title>
    <link rel="shortcut icon" type="image/png" href="assets\img\MCM Pool.png"/>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css">
    <link rel="stylesheet" href="assets/css/Login-Form-Clean.css">
    <link rel="stylesheet" href="assets/css/Navigation-Clean.css">
    <link rel="stylesheet" href="assets/css/styles.css">
</head>

<style>
    .border {
        display: inline-block;
        width: 80%;
        height: 80%;
        margin: 5%;
        border-radius: 4px;
        padding: 2%;
    }

    table.blueTable {
    border: 1px solid #000000;
    background-color: #FEFEFE;
    width: 100%;
    text-align: left;
    border-collapse: collapse;
    padding-top: 8px;
    }

    .thead {
        background: #0F89C2;
        font-weight: normal;
        color: #f2f2f2;
        text-align: center;
    }

    table.blueTable td, table.blueTable th {
    border: 1px solid #119ada;
    padding-top:3px ;
    }

    .btn-primary{
      border-color: #17a9ed;
      color: #f2f2f2;
      font-size: medium;
      background-color: #17a9ed;
    }
    .btn-primary:hover{
      border-color: #0b6893;
      color: #f2f2f2;
      font-size: medium;
      background-color: #0b6893;
    }
</style>

<body>
    <?php
    if (isset($_POST['logout'])) {
        session_destroy();
        exit;
    }

    ?>
    <nav class="navbar navbar-light navbar-expand-md navigation-clean" style="background: #0F89C2;">
        <div class="container">
        <img src="assets\img\MCM Pool (Edited).png" style="max-height: 60px; max-width: 60px;"> 
        &nbsp &nbsp
        <a class="navbar-brand" href="homepage.php" style="font-size:20px; color:#f2f2f2;">MCM Management System</br><span style="font-size: 12px; color:#f2f2f2;">Developed by Gp4+1</span></a>
        <button data-toggle="collapse" class="navbar-toggler" data-target="#navcol-1"><span class="sr-only">Toggle navigation</span><span class="navbar-toggler-icon"></span></button>
            <div class="collapse navbar-collapse" id="navcol-1">
                <ul class="nav navbar-nav ml-auto">
                    <li class="nav-item" role="presentation" style="font-size:medium; font-weight:bold;"><a class="nav-link" href="homepage.php" style='color:#f2f2f2;'>Homepage</a></li>
                    <li class="nav-item" role="presentation" style="font-size:medium; font-weight:bold;"><a class='nav-link' href='logout.php' style='color:#f2f2f2;'>Logout</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div>
        <div class="container">
            <div class="row">
                <div class="col-md-12"></div>
            </div>
        </div>
    </div>

    <span class="border">

        <div class="container">
            <div class='row'>
            <h4 class='card-title'> Update Job Details </h4><br>
            </div>
            <div class="row">
            <?php
                   
                    echo "<form name='frmImage' enctype='multipart/form-data' action='/job-update-process.php' method='post' class='frmImageUpload'>";
                    echo "<table border='1' class='blueTable'>";
                    echo "<tr>";
                    echo "<td class='thead'>Job ID: </td>";
                    echo "<td>&nbsp;&nbsp;$jobID</td>";
                    echo "</tr>";

                    echo "<tr>";
                    echo "<td class='thead'>Date: </td>";
                    echo "<td>&nbsp;&nbsp;$date </td>";
                    echo "</tr>";

                    echo "<tr>";
                    echo "<td class='thead'>Client Name: </td>";
                    echo "<td>&nbsp;&nbsp;$ClientName </td>";
                    echo "</tr>";

                    echo "<tr>";
                    echo "<td class='thead'>Work Location: </td>";
                    echo "<td>&nbsp;&nbsp;$Address </td>";
                    echo "</tr>";

                    echo "<tr>";
                    echo "<td class='thead'>Pool Size: </td>";
                    echo "<td>&nbsp;&nbsp;$PoolSize </td>";
                    echo "</tr>";

                    echo "<tr>";
                    echo "<td class='thead'>Main Employer: </td>";
                    echo "<td>&nbsp;&nbsp;$EmpID</td>";
                    echo "</tr>";

                    if (!empty($SupEmpID)) {
                    echo "<tr>";
                    echo "<td class='thead'>&nbsp;&nbsp;Assistant 1 ID: &nbsp;&nbsp;</td>";
                    echo "<td>&nbsp;&nbsp;$SupEmpID</td>";
                    echo "</tr>";
                    }

                    if (!empty($SupEmpID2)) {
                    echo "<tr>";
                    echo "<td class='thead'>&nbsp;&nbsp;Assistant 2 ID: &nbsp;&nbsp;</td>";
                    echo "<td>&nbsp;&nbsp;$SupEmpID2 </td>";
                    echo "</tr>";
                    }

                    echo "<tr>";
                    echo "<td class='thead'>Job Status: </td>";
                    echo "<td>  &nbsp;&nbsp;<select name='jobStatus' id='jobStatus'>
                                    <option value='Pending'>Pending</option>
                                    <option value='Completed'>Completed</option>
                                </select> 
                        </td>";
                    echo "</tr>";
                    
                    echo "<tr>";
                    echo "<td class='thead'>Job Remarks: </td>";
                    echo "<td>";
                    echo "<textarea class='form-control' name='jobRemarks' placeholder='Remarks' id='RemarksBox' style='height: 5%; width:150px;'>$JobRemarks</textarea>";
                    echo "</td>";
                    echo "</tr>";

                    echo "<tr>";
                    echo "<td class='thead'>Upload Image File:</td><br>";
                    echo "<td> &nbsp;&nbsp;<input name='userImage' type='file' class='inputFile '/> </td>";
                    echo "</tr>";
                    echo "</table>";
                    

                    echo "<input type='submit' value='Submit' class='btnSubmit btn-primary'/>";
                    ?>
            </div>

            </form>
        </div>
    </span>

    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
</body>

</html>



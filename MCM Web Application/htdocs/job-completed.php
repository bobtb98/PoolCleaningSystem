<!DOCTYPE html>
<html>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>MCM Management System</title>
    <link rel="shortcut icon" type="image/png" href="assets\img\MCM Pool.png"/>
    <link rel="stylesheet" href="assets/css/styles.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css">
    <link rel="stylesheet" href="assets/css/Login-Form-Clean.css">
    <link rel="stylesheet" href="assets/css/Navigation-Clean.css">
    
</head>

<style>
    .border {
            display: inline-block;
            border-color: #17a9ed !important ; 
            width: 80%;
            height: 80%;
            margin: 5%;
            border-radius: 4px;
            padding: 2%;
            
    }

    table.blueTable {
    border: 1px solid #119ada;
    background-color: #FEFEFE;
    width: 100%;
    text-align: left;
    border-collapse: collapse;
   
    }

    table.blueTable td, table.blueTable th {
    border: 1px solid #119ada;
    padding: 3px 2px;
    }

    table.blueTable thead {
    background: #0f89c2;
    }
    
    table.blueTable thead th {
    font-weight: normal;
    color: #f2f2f2;
    text-align: center;
    }

    table.blueTable tfoot .links {
    text-align: right;
    }

    table.blueTable tfoot .links a{
    display: inline-block;
    background: #1C6EA4;
    color: #FEFEFE;
    padding: 2px 8px;
    border-radius: 5px;
    }
</style>

<body>
    <?php
    //if detect user have logout
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
                    <li class="nav-item" role="presentation" style='font-size:medium; font-weight:bold;'><a class="nav-link" href="homepage.php" style='color:#f2f2f2;'>Homepage</a></li>
                    <li class='nav-item' role='presentation' style='font-size:medium; font-weight:bold;'><a class='nav-link' href='job-completed.php' style='color:#f2f2f2;'>Jobs Completed</a></li>
                    <li class='nav-item' role='presentation' style='font-size:medium; font-weight:bold;'><a class='nav-link' href='logout.php' style='color:#f2f2f2;'>Logout</a></li>
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


            <?php
                //div class row1
                echo "<div class='row'>";
                $currentMonth2 = date('F');
                //Title
                echo "<h4 class='card-title'> Jobs Completed on $currentMonth2</h4><br>";
                echo "</div>";

                //div class row2
                echo  "<div class='row'>";
                session_start();
                $empID = $_SESSION['EmpID'];

                        //Connect to MYSQL database
                        $servername = "localhost";
                        $username = "root";
                        $password = "";
                        $db = "sdm";
                        $connection = mysqli_connect($servername, $username, $password,$db);

                        //get current year and month
                        $currentYear = date("Y");
                        $currentMonth  = date("m");
                        $totalpay = 0;


                        //Run query against database
                        $query= "SELECT jobs.date, jobs.JobID, client.ClientName, client.Address, jobs.JobStatus, employee.Salary
                                    FROM client INNER JOIN jobs ON client.ClientID = jobs.ClientID 
                                    INNER JOIN employee ON jobs.EmpID = employee.EmpID OR jobs.SupEmpID = employee.EmpID OR jobs.SupEmpID2 = employee.EmpID
                                    WHERE (employee.EmpID = '$empID') AND (jobs.JobStatus = 'Completed') AND YEAR(jobs.date) = '$currentYear' AND MONTH(jobs.date) = '$currentMonth'
                                    ORDER BY date ASC";
                        $result=mysqli_query($connection, $query);

                        //Store jobID details into variables to post details later on
                        if (mysqli_num_rows($result) > 0) {
                                echo 
                                "<div class = 'table-responsive'>
                                <table class='blueTable'>
                                <thead>
                                <tr>
                                  <th>Date</th>
                                  <th>Job ID</th>
                                  <th>Client Name</th>
                                  <th>Worked Location</th>
                                  <th>Job Status</th>
                                  <th>Salary</th>
                                </tr>
                                </thead> ";
                                echo "<tbody>";
                                  while($row=mysqli_fetch_array($result)) {
                                        echo "<tr>";
                                          echo "<td>". $row['date'] ." </td>";
                                          echo "<td>". $row['JobID'] ." </td>";
                                          echo "<td>". $row['ClientName'] ." </td>";
                                          echo "<td>". $row['Address'] ." </td>";
                                          echo "<td>". $row['JobStatus'] ." </td>";
                                          echo "<td>". $row['Salary'] ." </td>";
                                        echo "</tr>";	
                                        $totalpay += $row['Salary'];
                                    }
                                echo "<td style='text-align:right;' colspan='5'><a style='color:a2a2a2; font-weight:bold;'> Total Pay &nbsp;&nbsp;</a></td>";
                                //make total 2 decimal places
                                echo "<td><a style='color:a2a2a2; font-weight:bold;'>".number_format((float)$totalpay, 2, '.', '')."</a></td>";
                                echo "</tbody>
                                </table>
                                </div>";
                        }
                        else {
                                echo "You have not yet completed any jobs this month.";
                        }
                echo "</div>";
            ?> 
            </form>
        </div>
    </span>

    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
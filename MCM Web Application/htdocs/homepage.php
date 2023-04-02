<!DOCTYPE html>
<html>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>MCM Management System</title>
    <link rel="shortcut icon" type="image/png" href="assets\img\MCM Pool.png"/>
    <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="/assets/styles.css">
    <link rel="stylesheet" href="/assets/fonts/ionicons.min.css">
    <link rel="stylesheet" href="/assets/css/Login-Form-Clean.css">
    <link rel="stylesheet" href="/assets/css/Navigation-Clean.css">
</head>

<style>
    #box {
    display: inline-block;
    width: 80%;
    height: 80%;
    margin: 5%;
    padding: 5%;
    border-radius: 4px;
    border-color: #17a9ed !important ; 
    }
  
    table.blueTable {
    border: 1px solid #000000;
    background-color: #FEFEFE;
    width: 100%;
    text-align: left;
    border-collapse: collapse;
    white-space: nowrap;
    padding: 10px 10px;
    }

    table.blueTable td, table.blueTable th {
    border: 0.2px solid #119ada;
    padding-right: 15px;
    }

    table.blueTable thead {
    background: #0f89c2;
    }
    
    table.blueTable thead th {
    font-weight: normal;
    color: #f2f2f2;
    text-align: center;
    }

    table.blueTable tbody{
      color : #2a2a2a;
    }

    table.blueTable tfoot .links {
    text-align: right;
    }

    table.blueTable tfoot .links a{
    display: inline-block;
    background: #0f89c2;
    color: #FEFEFE;
    padding: 2px 8px;
    border-radius: 5px;
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
    <nav class="navbar navbar-light navbar-expand-md navigation-clean" style="background: #0F89C2;">
        <div class="container">
        <img src="assets\img\MCM Pool (Edited).png" style="max-height: 60px; max-width: 60px;"> 
        &nbsp &nbsp
            <a class="navbar-brand" href="homepage.php" style="font-size:20px; color:#f2f2f2;">MCM Management System</br><span style="font-size: 12px; color:#f2f2f2;">Developed by Gp4+1</span></a>
            <button data-toggle="collapse" class="navbar-toggler" data-target="#navcol-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="navbar-toggler-icon"></span></button>
            <div class="collapse navbar-collapse"
                id="navcol-1">
                <?php
                session_start();
                if ($_SESSION['Role'] == "Full-Time Staff") {
                echo 
                "<ul class='nav navbar-nav ml-auto'>
                    <li class='nav-item' role='presentation' style='font-size:medium; font-weight:bold;'><a class='nav-link' href='homepage.php' style='color:#f2f2f2;'>Homepage</a></li>
                    <li class='nav-item' role='presentation' style='font-size:medium; font-weight:bold;'><a class='nav-link' href='logout.php' style='color:#f2f2f2;'>Logout</a></li>
                </ul>";
                }

                else if ($_SESSION['Role'] == "Part-Time Staff") {
                  echo 
                  "<ul class='nav navbar-nav ml-auto'>
                      <li class='nav-item' role='presentation' style='font-size:medium; font-weight:bold;'><a class='nav-link' href='homepage.php' style='color:#f2f2f2;'>Homepage</a></li>
                      <li class='nav-item' role='presentation' style='font-size:medium; font-weight:bold;'><a class='nav-link' href='job-completed.php' style='color:#f2f2f2;'>Jobs Completed</a></li>
                      <li class='nav-item' role='presentation'style='font-size:medium; font-weight:bold;' ><a class='nav-link' href='logout.php' style='color:#f2f2f2;'>Logout</a></li>
                  </ul>";
                }
                ?>
            </div>
        </div>
    </nav>
    
    <span class="border" id="box">
    <div class="container">  
        <div class="information">  
          <div class="row">
            <div class="card" style="width: max;">
              <div class="card-body" id="DisplayUserInformation">
                  
                  <?php                    
                    //store gloabl session variable to be use later on
                    $username = $_SESSION['Username'];
                    $empID = $_SESSION['EmpID'];
                    $role = $_SESSION['Role'];

                    //Connect to MYSQL database
                    $servername = "localhost";
                    $username = "root";
                    $password = "";
                    $db = "sdm";
                    $connection = mysqli_connect($servername, $username, $password,$db);

                    //Run query against database and retrieve staff name from employee table
                    $query= "SELECT employee.FName FROM employee WHERE employee.EmpID = '$empID';";
                    $result=mysqli_query($connection, $query);
                    if(mysqli_num_rows($result)==1) {
                      while($row=mysqli_fetch_array($result)) {
                        $empName = $row['FName'];
                      }
                    }
                    echo "<h4 class='card-title' style='color: #2a2a2a;'> $empName's Job Schedule </h4><br>";

                    // If user login is a Full Time Staff
                    if ($_SESSION['Role'] == "Full-Time Staff") {
                      //Run query0 against database to retrieve n display job schedule information for Full Time Staff
                      $query0= "SELECT DISTINCT jobs.date,  jobs.JobID, client.ClientName, client.Address, client.PoolSize, jobs.JobType, jobs.EmpID, jobs.SupEmpID, jobs.SupEmpID2, jobs.JobStatus
                                  FROM client INNER JOIN
                                  jobs ON client.ClientID = jobs.ClientID INNER JOIN
                                  employee ON jobs.EmpID = employee.EmpID OR jobs.SupEmpID = employee.EmpID OR jobs.SupEmpID2 = employee.EmpID
                                  WHERE ((jobs.EmpID = '$empID' OR jobs.SupEmpID = '$empID' OR jobs.SupEmpID2 = '$empID') AND jobs.JobStatus = 'Pending')
                                  ORDER BY jobs.date ASC";
                      $result0=mysqli_query($connection, $query0);
                      if	(mysqli_num_rows($result0)>0) {
                        echo 
                        "<div class = 'table-responsive'>
                        <table class='blueTable caption-top'>
                        <thead>
                        <tr>
                          <th>Date</th>
                          <th>Job ID</th>
                          <th>Client Name</th>
                          <th>Work Location</th>
                          <th>Pool Size</th>
                          <th>Job Type</th>
                          <th>Main Employer</th>
                          <th>Assistant 1 ID</th>
                          <th>Assistant 2 ID</th>
                          <th>Job Status</th>
                          <th>Modify</th>
                        </tr>
                        </thead> ";
                        echo "<tbody>";
                          while($row=mysqli_fetch_array($result0)) {
                                $jobID=$row['JobID'];
                                echo "<tr>";
                                  echo "<td>". $row['date'] ." </td>";
                                  echo "<td>". $row['JobID'] ." </td>";
                                  echo "<td>". $row['ClientName'] ." </td>";
                                  echo "<td>". $row['Address'] ." </td>";
                                  echo "<td>". $row['PoolSize'] ." </td>";
                                  echo "<td>". $row['JobType'] ." </td>";
                                  echo "<td>". $row['EmpID'] ." </td>";
                                  echo "<td>". $row['SupEmpID'] ." </td>";
                                  echo "<td>". $row['SupEmpID2'] ." </td>";
                                  echo "<td>". $row['JobStatus'] ." </td>";
                                  echo "<td>
                                  <form action=\"/job-update.php\" method=\"post\">
                                    <input class='btn btn-primary' type='submit' id='jobID' name='$jobID' value='Update Job' />
                                  </form>";
                                  echo "</td>";
                                echo"	</tr> ";	
                            }
                        echo "</tbody>
                        </table>
                        </div>";
                      }
                      else {
                        echo "There are no pending jobs assigned to you for now.";
                      }
                    }
                    // If user login is a Part Time Staff
                    else if ($_SESSION['Role'] == "Part-Time Staff") {
                      //Run query0 against database to retrieve n display job schedule information for Full Time Staff
                      $query2= "SELECT DISTINCT jobs.date,  jobs.JobID, client.ClientName, client.Address,  jobs.JobType,  jobs.EmpID, jobs.SupEmpID, jobs.SupEmpID2
                                  FROM client INNER JOIN
                                  jobs ON client.ClientID = jobs.ClientID INNER JOIN
                                  employee ON jobs.EmpID = employee.EmpID OR jobs.SupEmpID = employee.EmpID OR jobs.SupEmpID2 = employee.EmpID
                                  WHERE ((jobs.EmpID = '$empID' OR jobs.SupEmpID = '$empID' OR jobs.SupEmpID2 = '$empID') AND jobs.JobStatus = 'Pending')
                                  ORDER BY jobs.date ASC";
                      $result2=mysqli_query($connection, $query2);
                      if	(mysqli_num_rows($result2)>0) {
                      echo 
                      "<div class = 'table-responsive'>
                      <table class= 'blueTable'>
                      <thead>
                      <tr>
                      <th>Date</th>
                      <th>Job ID</th>
                      <th>Client Name</th>
                      <th>Work Location</th>
                      <th>Job Type</th>
                      <th>Guide by Employee ID</th>

                      </tr>
                      </thead> ";
                      echo "<tbody>";
                      while($row=mysqli_fetch_array($result2)) {
                      $jobID=$row['JobID'];
                      echo "<tr>";
                      echo "<td>". $row['date'] ." </td>";
                      echo "<td>". $row['JobID'] ." </td>";
                      echo "<td>". $row['ClientName'] ." </td>";
                      echo "<td>". $row['Address'] ." </td>";
                      echo "<td>". $row['JobType'] ." </td>";
                      echo "<td>". $row['EmpID'] ." </td>";
                      echo"	</tr> ";	
                      }
                      echo "</tbody>
                      </table>
                      </div>";       
                    } 
                    else {
                      echo "There are no pending jobs assigned to you for now.";
                    }
                  }
                  ?>
                  <!-- Display from database -->
              </div>
            </div>
          </div>         
        </div>
    </div>
</span>    

   <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

</body>

</html>
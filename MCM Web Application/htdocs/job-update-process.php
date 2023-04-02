<?php
session_start();

$jobID = $_SESSION['JobID'];

//retrieve data transfer from form(post method) in job-update.php
$jobRemarks = $_POST["jobRemarks"];
$jobStatus = $_POST["jobStatus"];

$conn = mysqli_connect("localhost", "root", "", "sdm");
if (count($_FILES) > 0) {
    if (is_uploaded_file($_FILES['userImage']['tmp_name'])) {
        //convert the image to blob data type 
        $imgData = addslashes(file_get_contents($_FILES['userImage']['tmp_name']));

        //need the image extension
        $imageProperties = getimageSize($_FILES['userImage']['tmp_name']);
        
        // DO NOT TOUCH THE QUERY
        $sql = "UPDATE jobs SET PictureType = '{$imageProperties['mime']}' , Picture = '{$imgData}', JobStatus = '$jobStatus' , JobRemarks = '$jobRemarks'
        WHERE JobStatus = 'Pending' AND JobID = '$jobID'";

        //$sql = "UPDATE jobs SET PictureType = '{$imageProperties['mime']}' , Picture = '{$imgData}' WHERE JobID = 500001";

        $current_id = mysqli_query($conn, $sql) or die("<b>Error:</b> Problem on Image Insert<br/>" . mysqli_error($conn));
        // if (isset($current_id)) {
        // 	header("Location: listImages.php");
        // }
        echo "got pic";
    }
    else {
        // DO NOT TOUCH THE QUERY
        $sql1 = "UPDATE jobs SET JobStatus = '$jobStatus' WHERE JobStatus = 'Pending' AND JobID = '$jobID'";
    
        //$sql = "UPDATE jobs SET PictureType = '{$imageProperties['mime']}' , Picture = '{$imgData}' WHERE JobID = 500001";
    
        $current_id = mysqli_query($conn, $sql1) or die("<b>Error:</b> Problem on changing job status from pending to compelete<br/>" . mysqli_error($conn));
        echo "no pic";
    
    }

}
 echo '<script>window.location.href = "homepage.php";</script>';
?>
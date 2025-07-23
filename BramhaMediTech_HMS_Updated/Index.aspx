<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>




<!DOCTYPE html>
<html>
<head>
    <title>Camera Capture</title>
</head>
<body>
    <video id="video" width="640" height="480" autoplay></video>
    <button id="capture">Capture</button>
    <canvas id="canvas" width="640" height="480" style="display:none;"></canvas>

    <script>
        var video = document.getElementById('video');
        var canvas = document.getElementById('canvas');
        var context = canvas.getContext('2d');
        var captureButton = document.getElementById('capture');

        // Access the webcam
        navigator.mediaDevices.getUserMedia({ video: true })
            .then(function (stream) {
                video.srcObject = stream;
            })
            .catch(function (err) {
                console.log('Error accessing the webcam:', err);
            });

        // Capture button click event
        captureButton.addEventListener('click', function () {
            context.drawImage(video, 0, 0, canvas.width, canvas.height);
            // Convert the canvas content to a data URL
            var imageData = canvas.toDataURL('image/png');
            // Send the image data to the server
            sendDataToServer(imageData);
        });

        // Send image data to the server
        function sendDataToServer(imageData) {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                if (xhr.readyState === XMLHttpRequest.DONE) {
                    if (xhr.status === 200) {
                        console.log('Image uploaded successfully.');
                    } else {
                        console.log('Error uploading image.');
                    }
                }
            };
            xhr.open('POST', 'UploadImageHandler.ashx', true);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.send('imageData=' + encodeURIComponent(imageData));
        }
    </script>
</body>
</html>

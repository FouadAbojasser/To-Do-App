// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//=========================================================================================
// Script of Patient Date of Birth Picker
document.addEventListener('DOMContentLoaded', function () {
    // DOB Picker (past dates only)
    flatpickr(".dob-picker", {
        maxDate: "today",  // Only allows dates before today
        dateFormat: "Y-m-d",
        allowInput: false,
        clickOpens: true,
        theme: "light",
        onReady: function (selectedDates, dateStr, instance) {
            // Optional: Customize the calendar further
            instance.calendarContainer.classList.add('dob-calendar');
        }
    });
});


//=========================================================================================
//script for Appointment Date and Time picker
function initDatePickers() {
    const datePickers = document.querySelectorAll('.date-picker');
    if (datePickers.length > 0) {
        flatpickr(".date-picker", {
            minDate: "today",
            //disable: [
            //    function (date) {
            //        return (date.getDay() === 5 || date.getDay() === 6);
            //    }
            //],
            dateFormat: "Y-m-d",
            allowInput: false,
            clickOpens: true
        });
    }
}
document.addEventListener('DOMContentLoaded', initDatePickers);

// Also initialize for dynamically loaded content
document.addEventListener('turbo:load', initDatePickers); // If using Turbo/Hotwire
document.addEventListener('ajaxComplete', initDatePickers); // If using jQuery AJAX

//=========================================================================================
//Script for Appointment Time Picker 
const timePicker = document.getElementById('timePicker');
const startHour = 9;  // 9 AM
const endHour = 21;    // 9 PM (21:00 in 24-hour format)

for (let hour = startHour; hour <= endHour; hour++) {
    for (let minute = 0; minute < 60; minute += 30) {
        if (hour === endHour && minute > 0) break;
        const time24 = `${String(hour).padStart(2, '0')}:${String(minute).padStart(2, '0')}`;
        const time12 = new Date(`2000-01-01T${time24}:00`).toLocaleTimeString('en-US', {
            hour: '2-digit',
            minute: '2-digit',
            hour12: true
        });

        const option = document.createElement('option');
        option.value = time24;
        option.textContent = time12;
        timePicker.appendChild(option);
    }
}

var festivalRooms = festivalRooms || (function () {
    var _args = {}; // private

    return {
        init: function (Args) {
            _args = Args;
            // some other initialising

        },
        getFestivalRooms: function () {
            $("#RoomId").empty();
            var url = _args[0];
            $.ajax({
                type: 'POST',
                url: _args[0],
                //contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: { id: $("#FestivalId").val() },
                success: function (rooms) {
                    // rooms contains the JSON formatted list
                    // of rooms passed from the controller
                    $.each(rooms, function (i, room) {
                        $("#RoomId").append('<option value="'
    + room.Value + '">'
    + room.Text + '</option>');
                    });
                },
                error: function (ex) {
                    alert('Failed to retrieve Rooms.' + ex);
                }
            });
            return false;
        },

    };
}());

$(document).ready(function () {
    //Dropdownlist Selected change Festival event
    $("#FestivalId").change(function () { festivalRooms.getFestivalRooms() });
});
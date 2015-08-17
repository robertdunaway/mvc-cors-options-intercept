/*global mashupApp:false */
/*global ngWidgets:false */

mashupApp.controller('quality.CqtsTransExportController',
    ['qualityDataService', function (qualityDataService) {
        'use strict';

        var vm = this;


        // ---------------------------------------------------
        // Set up default date values for date options
        // ---------------------------------------------------
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();

        vm.beginDate = new Date(mm + '-' + '01' + '-' + yyyy);
        vm.endDate = new Date(mm + '-' + (dd + 1) + '-' + yyyy);
        // ---------------------------------------------------


        var data = {};

        // prepare the data for grid
        var source =
        {
            dataType: 'json',
            dataFields: [
                { name: 'Create_Date', type: 'date' },
                { name: 'Credit_Approval_Date', type: 'date' },
                { name: 'Complaint_Number' },
                { name: 'Transit_Damage_Desc' },
                { name: 'Load' },
                { name: 'Order_Number' },
                { name: 'Transit_Damage' },
                { name: 'Carrier' },
                { name: 'No_of_Units' },
                { name: 'Weight' },
                { name: 'Credit_Dollar' },
                { name: 'Customer' },
                { name: 'Consignee' },
                { name: 'City' },
                { name: 'State' },
                { name: 'Mode' },
                { name: 'Vehicle' },
                { name: 'Trans_Ship_To_Name' },
                { name: 'Invoice' },
                { name: 'Producing_Mill' },
                { name: 'Claim_Status' },
                { name: 'File_Date', type: 'date' },
                { name: 'Closed_Date', type: 'date' },
                { name: 'Customer_Claim_Dollars' },
                { name: 'Activity_Type' },
                { name: 'Entry_Type' },
                { name: 'Entry_Dollars' },
            ],
            localData: data
        };

        var dataAdapter = new ngWidgets.ngx.dataAdapter(source);

        // Grid settings
        vm.pageSize = 10;
        vm.exportSettings = { columnsHeader: true, hiddenColumns: true, fileName: 'cqtsTransExport-' + Date.now() };
        vm.gridSettings =
        {
            pageable: true,
            sortable: true,
            width: '98%',
            created: function (args) {
                vm.grid = args.instance;
            },
            source: dataAdapter,
            columns: [
                { text: 'Complaint_Number', datafield: 'Complaint_Number', width: '150' },
                { text: 'Order_Number', datafield: 'Order_Number', width: '125' },
                { text: 'Create_Date', datafield: 'Create_Date', width: '175', cellsFormat: 'd' },
                { text: 'Customer', datafield: 'Customer', width: '225' },
                { text: 'Consignee', datafield: 'Consignee', width: '225' },
                { text: 'Transit_Damage_Desc', datafield: 'Transit_Damage_Desc', width: '150' },
                { text: 'Credit_Approval_Date', datafield: 'Credit_Approval_Date', width: '175', cellsFormat: 'd' },
                { text: 'Load', datafield: 'Load', width: '75' },
                { text: 'Transit_Damage', datafield: 'Transit_Damage', width: '250' },
                { text: 'Carrier', datafield: 'Carrier', width: '275' },
                { text: 'No_of_Units', datafield: 'No_of_Units', width: '100' },
                { text: 'Weight', datafield: 'Weight', width: '75' },
                { text: 'Credit_Dollar', datafield: 'Credit_Dollar', width: '100', align: 'right', cellsFormat: 'c2' },
                { text: 'City', datafield: 'City', width: '150' },
                { text: 'State', datafield: 'State', width: '75' },
                { text: 'Mode', datafield: 'Mode', width: '75' },
                { text: 'Vehicle', datafield: 'Vehicle', width: '125' },
                { text: 'Trans_Ship_To_Name', datafield: 'Trans_Ship_To_Name', width: '225' },
                { text: 'Invoice', datafield: 'Invoice', width: '100' },
                { text: 'Producing_Mill', datafield: 'Producing_Mill', width: '250' },
                { text: 'Claim_Status', datafield: 'Claim_Status', width: '125' },
                { text: 'File_Date', datafield: 'File_Date', width: '175', cellsFormat: 'd' },
                { text: 'Closed_Date', datafield: 'Closed_Date', width: '175', cellsFormat: 'd' },
                { text: 'Customer_Claim_Dollars', datafield: 'Customer_Claim_Dollars', width: '200' },
                { text: 'Activity_Type', datafield: 'Activity_Type', width: '150' },
                { text: 'Entry_Type', datafield: 'Entry_Type', width: '150' },
                { text: 'Entry_Dollars', datafield: 'Entry_Dollars', width: '125', align: 'right', cellsFormat: 'c2' },
            ]
        };


        vm.beginDateTimeSettings = {
            width: '100%', height: '25px', dropDownHorizontalAlignment: 'right'
        };
        vm.beginDateTimeSettings.formatString = 'MM-dd-yyyy';

        vm.endDateTimeSettings = {
            width: '100%', height: '25px', dropDownHorizontalAlignment: 'right'
        };
        vm.endDateTimeSettings.formatString = 'MM-dd-yyyy';


        // Export functions
        vm.excelExportClick = function () {
            vm.grid.exportData('xls');
        };

        vm.csvExportClick = function () {
            vm.grid.exportData('csv');
        };


        var cacheMinutes = 0;

        vm.getDataClick = function () {
            qualityDataService.getCQTSAdHocTransData(cacheMinutes, vm.beginDate, vm.endDate).then(function (data) {
                source.localData = data;
                dataAdapter = new ngWidgets.ngx.dataAdapter(source);
                vm.grid.updateBoundData();
            });
        };

    }]);
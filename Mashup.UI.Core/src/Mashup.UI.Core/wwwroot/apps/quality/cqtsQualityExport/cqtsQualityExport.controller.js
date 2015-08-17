/*global mashupApp:false */
/*global ngWidgets:false */

mashupApp.controller('quality.CqtsQualityExportController',
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
                { name: 'Complaint_Supplement' },
                { name: 'Order_Ref_Nbr' },
                { name: 'Grade_Name' },
                { name: 'PO' },
                { name: 'Basis_Wgt' },
                { name: 'Defect' },
                { name: 'No_of_Units' },
                { name: 'Weight' },
                { name: 'Credit_Dollar' },
                { name: 'Customer' },
                { name: 'Consignee' },
                { name: 'City' },
                { name: 'State' },
                { name: 'Facility' },
                { name: 'Machine' },
                { name: 'MFG_Date', type: 'date' }
            ],
            localData: data
        };

        var dataAdapter = new ngWidgets.ngx.dataAdapter(source);

        // Grid settings
        vm.pageSize = 10;
        vm.exportSettings = { columnsHeader: true, hiddenColumns: true, fileName: 'cqtsQualityExport-' + Date.now() };
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
                { text: 'Order_Ref_Nbr', datafield: 'Order_Ref_Nbr', width: '120' },
                { text: 'Create_Date', datafield: 'Create_Date', width: '175', cellsFormat: 'd' },
                { text: 'Customer', datafield: 'Customer', width: '250' },
                { text: 'Consignee', datafield: 'Consignee', width: '250' },
                { text: 'Grade_Name', datafield: 'Grade_Name', width: '250' },
                { text: 'Credit_Approval_Date', datafield: 'Credit_Approval_Date', width: '175', cellsFormat: 'd' },
                { text: 'Complaint_Supplement', datafield: 'Complaint_Supplement', width: '175' },
                { text: 'PO', datafield: 'PO', width: '150' },
                { text: 'Basis_Wgt', datafield: 'Basis_Wgt', width: '100' },
                { text: 'Defect', datafield: 'Defect', width: '300' },
                { text: 'No_of_Units', datafield: 'No_of_Units', width: '120' },
                { text: 'Weight', datafield: 'Weight', width: '75', cellsFormat: 'f' },
                { text: 'Credit_Dollar', datafield: 'Credit_Dollar', width: '100', align: 'right', cellsFormat: 'c2' },
                { text: 'City', datafield: 'City', width: '200' },
                { text: 'State', datafield: 'State', width: '75' },
                { text: 'Facility', datafield: 'Facility', width: '120' },
                { text: 'Machine', datafield: 'Machine', width: '100' },
                { text: 'MFG_Date', datafield: 'MFG_Date', width: '175', cellsFormat: 'd' },
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
            qualityDataService.getCQTSAdHocQualityData(cacheMinutes, vm.beginDate, vm.endDate).then(function (data) {
                source.localData = data;
                dataAdapter = new ngWidgets.ngx.dataAdapter(source);
                vm.grid.updateBoundData();
            });
        };

    }]);
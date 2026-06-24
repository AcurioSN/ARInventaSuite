"use strict";

var KTLayoutSidebar = function() {
    var _initUserChart = function () {
        var element = document.querySelector("#kt_user_chart");
        var height = parseInt(KTUtil.css(element, 'height'));

        if (!element) {
            return;
        }

        var options = {
            series: [74],
            chart: {
                fontFamily: 'inherit',
                height: height,
                type: 'radialBar',
            },
            plotOptions: {
                radialBar: {
                    hollow: {
                        margin: 0,
                        size: "78%"
                    },
                    dataLabels: {
                        showOn: "always",
                        name: {
                            show: false,
                            fontWeight: '700'
                        },
                        value: {
                            color: '#5E6278',
                            fontSize: "30px",
                            fontWeight: '700',
                            offsetY: 6,
                            show: true,
                            formatter: function (val) {
                                return val + '%';
                            }
                        }
                    },
                    track: {
                        background: '#00A3FF',
                        strokeWidth: '100%'
                    }
                }
            },
            colors: ['#F1416C'],
            stroke: {
                lineCap: "round",
            },
            labels: ["Progress"]
        };

        var chart = new ApexCharts(element, options);

        chart.render();
    }

    var _initUserStatsChart = function(tabSelector, chartSelector, data1, initByDefault) {
        var element = document.querySelector(chartSelector);
        var height = parseInt(KTUtil.css(element, 'height'));

        if (!element) {
            return;
        }

        var options = {
            series: [{
                name: 'Profit',
                data: data1
            }],
            chart: {
                fontFamily: 'inherit',
                type: 'bar',
                height: height,
                toolbar: {
                    show: false
                }
            },
            plotOptions: {
                bar: {
                    horizontal: false,
                    columnWidth: ['30%'],
                    borderRadius: 4
                },
            },
            legend: {
                show: false
            },
            dataLabels: {
                enabled: false
            },
            stroke: {
                show: true,
                width: 2,
                colors: ['transparent']
            },
            xaxis: {
                crosshairs: {
                    show: false
                },
                categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
                axisBorder: {
                    show: false,
                },
                axisTicks: {
                    show: false
                },
                labels: {
                    style: {
                        colors: '#823FD9',
                        fontSize: '12px'
                    }
                }
            },
            yaxis: {
                crosshairs: {
                    show: false
                },
                labels: {
                    style: {
                        colors:'#823FD9',
                        fontSize: '12px'
                    }
                }
            },
            states: {
                normal: {
                    filter: {
                        type: 'none',
                        value: 0
                    }
                },
                hover: {
                    filter: {
                        type: 'none',
                    }
                },
                active: {
                    allowMultipleDataPointsSelection: false,
                    filter: {
                        type: 'none',
                        value: 0
                    }
                }
            },
            fill: {
                opacity: 1
            },            
            tooltip: {
                style: {
                    fontSize: '12px'
                },
                y: {
                    formatter: function (val) {
                        return "$" + val + "k"
                    }
                }
            },
            colors: ['#661DC5'],
            grid: {
                borderColor: '#661DC5',
                strokeDashArray: 4,
                yaxis: {
                    lines: {
                        show: true
                    }
                }
            }
        };

        var chart = new ApexCharts(element, options);

        var init = false;
        var tab = document.querySelector(tabSelector);
        
        if (initByDefault === true) {
            chart.render();
            init = true;
        }        

        tab.addEventListener('shown.bs.tab', function (event) {
            if (init == false) {
                chart.render();
                init = true;
            }
        })
    }

    // Public methods
    return {
        init: function() {
            // Initialize

            // User progress chart
            _initUserChart();

            // User stat charts
            _initUserStatsChart('#kt_sidebar_tab_1', '#kt_sidebar_tab_1_chart', [40, 30, 25, 40, 50, 30], false);
            _initUserStatsChart('#kt_sidebar_tab_2', '#kt_sidebar_tab_2_chart', [30, 30, 25, 45, 30, 40], false);
            _initUserStatsChart('#kt_sidebar_tab_3', '#kt_sidebar_tab_3_chart', [25, 30, 40, 30, 35, 30], true);
            _initUserStatsChart('#kt_sidebar_tab_4', '#kt_sidebar_tab_4_chart', [25, 30, 35, 40, 50, 30], false);
            _initUserStatsChart('#kt_sidebar_tab_5', '#kt_sidebar_tab_5_chart', [40, 20, 50, 50, 55, 45], false);
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTLayoutSidebar.init();
});

// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
    module.exports = KTLayoutSidebar;
}
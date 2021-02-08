﻿$(document).ready(function () {
    $('.table').DataTable(
        {
            iDisplayLength: 50,
            "ordering": false,
            "order": [],
            dom: 'Bfrtip',
            buttons: [
                'print'
            ],
            initComplete: function () {
                var row_count = 0;

                this.api().columns(0).every(function () {

                    var column = this;

                    var disabled = row_count != 0 ? "disabled" : "";

                    var default_filter_text = row_count == 0 ? "- الكل -" : "";

                    var header_text = $(column.header()).text().trim();

                    var select = $('<select class="form-control" ' + disabled + '><option value="">' + default_filter_text + '</option></select>')
                        .insertBefore($('.table'))
                        .on('change', function () {
                            var val = $.fn.dataTable.util.escapeRegex(
                                $(this).val()
                            );
                            column.search(val ? '^' + val + '$' : '', true, false).draw();
                        });

                    column.data().unique().each(function (d, j) {
                        select.append('<option value="' + d + '">' + d + '</option>')
                    });

                    if (row_count == 0) {
                        select.wrap($("<div class='branchFilter'><label>" + header_text + "</label>"));
                    }
                    row_count++;
                });
            }
        }
    );
});

$(document).ready(function () {

    $(".passwordShow").mousedown(function () {
        $(this).closest('tr').find(".pwd-field").attr("type", "text");
    })

    $(".passwordShow").mouseup(function () {
        $(".pwd-field").attr("type", "password");
    })
})

$(document).ready(function () {
    var rootNode = $(".branchesContainer div[data-parent='none']");
    if (rootNode.length) {
        var rootNodeId = rootNode.attr("id").toString();

        var chart_config = {
            chart: {
                container: "#treeHolder",
                node: {
                    HTMLclass: 'fancybox',
                    collapsable: false
                },
                animateOnInit: true,
                animation: {
                    nodeAnimation: "easeOutBounce",
                    nodeSpeed: 700,
                    connectorsAnimation: "bounce",
                    connectorsSpeed: 700
                }
            },
            nodeStructure: generateList(rootNodeId)
        };

        tree = new Treant(chart_config);
    }
})

//returns json object generated by knowing the id selector
function generateList(rootId) {
    var rootObject = $("#" + rootId);
    var data = new Object();
    var childId;

    //if is pseudo element
    if (rootObject.data("ispseudo") == "1") {
        data.pseudo = true;
    } else {
        data.text = {
            name: rootObject.text(),
            id: rootObject.attr("id")
        };
    }

    var children = $("div[data-parent=" + rootId + "]").toArray().reverse();

    //if does not have children
    if (children.length == 0) {
        return JSON.parse(JSON.stringify(data));
    }
    data.children = new Array();
    children.forEach(function (item) {
        data.children.push(generateList($(item).attr("id")));
    })

    return JSON.parse(JSON.stringify(data));
}


$(document).ready(function () {
    $(".collapse-switch").remove();
    $('.fancybox').click(function () {
        var branchId = $(this).children(".node-id:first").text();
        var dataContainer = $(".dataContainer div[data-branch-id='" + branchId + "']");
        var dataId = dataContainer.attr("id");

        if (dataContainer.length > 0) {
            //var link = "#".concat(dataId).concat("_wrapper");
            var link = "#".concat(dataId);

            $.fancybox([
                {
                    href: link,
                    autoSize: true, // shouldn't be true ?
                    fitToView: true,
                    animationEffect: "zoom",
                }
            ]);
        }
    });
})
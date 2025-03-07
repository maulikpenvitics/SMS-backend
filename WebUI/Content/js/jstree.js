$(function () {
    $('#textbox').blur(function () {
        $('#jstree').jstree({
            "core": {
                "themes": {
                    "variant": "large",
                    "icons": false
                },
                'data': {
                    'url': '/Home/Nodes',
                    'data': function (node) {
                        return { 'id': node.id };
                    },

                }
            },
            "checkbox": {
                "keep_selected_style": false
            },
            "plugins": ["wholerow", "checkbox"],

        });


        $('#jstree').on('changed.jstree', function (e, data) {
            var i, j, r = [];
            for (i = 0, j = data.selected.length; i < j; i++) {
                r.push(data.instance.get_node(data.selected[i]).text);
            }
            alert('Selected: ' + r.join(', '));
            // $('#event_result').html('Selected: ' + r.join(', '));
        }).jstree();
    });
});
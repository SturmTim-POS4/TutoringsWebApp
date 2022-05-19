$(() => {
    const baseURL = 'http://localhost:5000/';
    const schulstufen = ['1', '2', '3', '4', '5'];

    $.getJSON(`${baseURL}api/clazz`)
        .then(clazzes => {
            console.log('clazzes received');
            for (const clazz of clazzes) {
                $.getJSON(`${baseURL}Students/${clazz.name}`)
                    .then(students => {
                        console.log('students received');
                        for (const student of students) {
                            $('<option>').html(student.name)
                                .appendTo('#cbStudents')
                                .val(student.id);
                        }
                        $('#cbStudents').change();
                    });
            }
        });

    $.getJSON(`${baseURL}api/clazz`)
        .then(clazzes => {
            console.log('clazzes received');
            for (const clazz of clazzes) {
                $('<button>').html(clazz.name)
                    .appendTo('#divClazzes')
                    .val(clazz.name)
                    .click(() => {
                        $.getJSON(`${baseURL}Students/${clazz.name}`)
                            .then(students => {
                                console.log('students received');

                                $('#cbStudents').empty();
                                for (const student of students) {
                                    $('<option>').html(student.name)
                                        .appendTo('#cbStudents')
                                        .val(student.id);
                                }
                                $('#cbStudents').change();
                            });


                    });
            }
        });

    schulstufen.forEach(schulstufe => {
        $('<input>').attr('type', 'radio')
            .attr('name', 'schulstufe')
            .val(schulstufe)
            .appendTo('#divSchulstufen');
        $('<label>').html(schulstufe)
            .appendTo('#divSchulstufen');
        $('<br>')
            .appendTo('#divSchulstufen');

    });

    $.getJSON(`${baseURL}api/subject`)
        .then(subjects => {
            console.log('subjects received');
            for (const subject of subjects) {
                $('<input>').attr('type', 'radio')
                    .attr('name', 'subject')
                    .appendTo('#divSubjects')
                    .val(subject.subjectId);
                $('<label>').html(subject.name)
                    .appendTo('#divSubjects');
                $('<br>')
                    .appendTo('#divSubjects');
            }
        });



    $('#cbStudents').change(() => {

        $('#studentName').html($('#cbStudents option:selected').html());


        $.getJSON(`${baseURL}students/${$('#cbStudents option:selected').val()}/Tutorings`).
        then(tutorings => {
            $('#ulTutorings').empty();
            $('#lblTutoring').html(`${tutorings.length} Nachhilfen`);
            console.log('tutorings received')
            for (const tutoring of tutorings) {
                $('<option>').html(`${tutoring.subjectName} in ${tutoring.schulstufe}`)
                    .appendTo('#ulTutorings');
            }
        })

    });





    $('#btnAddTutoring').click(() => {
        const studentId = $('#cbStudents').val();
        const subjectId = $('input[name=subject]:checked').val();
        const schulstufe = $('input[name=schulstufe]:checked').val();
        console.log(studentId, subjectId, schulstufe);
        const tutoring = {
            "studentId": studentId,
            "subjectId": subjectId,
            "schulstufe": schulstufe
        };
        $.ajax({
            url: `${baseURL}Students/Tutoring`,
            type: 'POST',
            data: JSON.stringify(tutoring),
            contentType: 'application/json'
        });

        $('#cbStudents').change();
    });
});
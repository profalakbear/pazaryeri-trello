// Dynamically create a new list
function createList(listTitle) {
    var list = document.createElement('div');
    list.className = 'col-md-3';
    list.innerHTML = `
      <div class="card">
        <div class="card-header list-header">${listTitle}</div>
        <div class="card-body list-body" id="sortable">
          <!-- Cards will be dynamically added here -->
        </div>
        <div class="card-footer">
          <button class="btn btn-sm btn-info edit-list">Edit</button>
          <button class="btn btn-sm btn-danger delete-list">Delete</button>
          <button class="btn btn-sm btn-primary add-card">Add Card</button> <!-- Added Add Card button -->
        </div>
      </div>
    `;
    document.getElementById('listsContainer').appendChild(list);

    // Attach event listeners to the newly created list
    attachListEventListeners(list);

    // Make the list droppable
    $(list.querySelector('.card-body')).droppable({
        accept: ".card",
        drop: function (event, ui) {
            $(this).append(ui.draggable[0]);
        }
    });
}

// Attach event listeners to the newly created list
function attachListEventListeners(list) {
    // Event listener for editing list name
    list.querySelector('.edit-list').addEventListener('click', function () {
        var newTitle = prompt('Enter new list title:');
        if (newTitle) {
            list.querySelector('.list-header').textContent = newTitle;
        }
    });

    // Event listener for deleting a list
    list.querySelector('.delete-list').addEventListener('click', function () {
        list.remove();
    });

    // Event listener for adding a new card
    list.querySelector('.add-card').addEventListener('click', function () {
        var cardTitle = prompt('Enter card title:');
        var cardDesc = prompt('Enter card description:');
        if (cardTitle && cardDesc) { // Ensure both title and description are provided
            var card = createCard(cardTitle, cardDesc);
            list.querySelector('.list-body').appendChild(card);
        }
    });
}

// Event listener for adding a new list
document.getElementById('addListBtn').addEventListener('click', function () {
    var listTitle = prompt('Enter list title:');
    var listCount = $(this).attr('list-count');
    var userId = $('#username').attr('user-id');
    var position = parseInt(listCount) + 1;

        //public int ID { get; set; }
        //public int UserID { get; set; }
        //public string Title { get; set; }
        //public int Position { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

    var jsonData = {
        UserID: userId,
        Title: listTitle,
        Position: position
    }

    $.ajax({
        url: 'http://localhost:13741/api/ListItems',
        method: 'POST', 
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (response) {
            // Handle success response
            createList(listTitle);
        },
        error: function (xhr, status, error) {
            // Handle error response
            console.error('Error:', error);
        }
    });
});

// Dynamically create a new card with title and description
function createCard(cardTitle, cardDesc) {
    var card = document.createElement('div');
    card.className = 'card';
    card.innerHTML = `
      <div class="card-header">${cardTitle}</div>
      <div class="card-body">${cardDesc}</div>
      <div class="card-footer">
        <button class="btn btn-sm btn-info edit-card">Edit</button>
        <button class="btn btn-sm btn-danger delete-card">Delete</button>
      </div>
    `;
    // Make the card draggable
    $(card).draggable({
        revert: "invalid", // Revert if not dropped in a droppable area
        helper: "clone" // Clone the card when dragging
    });

    // Attach event listeners to the newly created card
    attachCardEventListeners(card);

    return card;
}

// Attach event listeners to the newly created card
function attachCardEventListeners(card) {
    // Event listener for editing card title and description
    card.querySelector('.edit-card').addEventListener('click', function () {
        var newTitle = prompt('Enter new card title:');
        var newDesc = prompt('Enter new card description:');
        if (newTitle && newDesc) {
            card.querySelector('.card-header').textContent = newTitle;
            card.querySelector('.card-body').textContent = newDesc;
        }
    });

    // Event listener for deleting a card
    card.querySelector('.delete-card').addEventListener('click', function () {
        card.remove();
    });
}

// Initialize drag and drop functionality for cards
$(function () {
    $('.list-body').droppable({
        accept: ".card",
        drop: function (event, ui) {
            $(this).append(ui.draggable[0]);
        }
    });
});

namespace StickersTemplate.Cards
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Bot.Schema;
    using StickersTemplate.Models;

    public class UserPreviewCard
    {
        private readonly User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPreviewCard"/> class.
        /// </summary>
        /// <param name="user">The <see cref="user"/> for this card.</param>
        public UserPreviewCard(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
        }

        /// <summary>
        /// Turns the card into an <see cref="Attachment"/>.
        /// </summary>
        /// <returns>An <see cref="Attachment"/>.</returns>
        public Attachment ToAttachment()
        {
            var card = new ThumbnailCard
            {
                Title = this.user.Name,
                Images = new List<CardImage>()
                {
                    new CardImage
                    {
                        Alt = this.user.Name,
                        Url = this.user.ImageUrl.ToString()
                    }
                }
            };

            return card.ToAttachment();
        }
    }
}

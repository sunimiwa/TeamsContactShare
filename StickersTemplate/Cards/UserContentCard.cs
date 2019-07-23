namespace StickersTemplate.Cards
{
    using System;
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using StickersTemplate.Extensions;
    using StickersTemplate.Models;
    public class UserContentCard
    {
        private readonly User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserContentCard"/> class.
        /// </summary>
        /// <param name="sticker">The <see cref="sticker"/> for this card.</param>
        public UserContentCard(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
        }

        /// <summary>
        /// Turns the card into an <see cref="Attachment"/>.
        /// </summary>
        /// <returns>An <see cref="Attachment"/>.</returns>
        public Attachment ToAttachment()
        {
            var contentCard = new HeroCard
            {
                Title = this.user.Name,
                Subtitle = this.user.JobTitle,

                // Description in search response is pre-truncated with elipsis, which is what we want for text. Description in list response is too long to present in a card
                Text = this.user.Location,
                Images = new List<CardImage>()
                {
                    new CardImage
                    {
                        Alt = this.user.Name,
                        Url = this.user.ImageUrl.ToString()
                    }
                },
                Tap = new CardAction
                {
                    Type = ActionTypes.OpenUrl,
                    Value = this.user.ChatDeepLink,
                }
            };

            return contentCard.ToAttachment();
        }
    }
}

using System;
using Microsoft.Bot.Schema;
using StickersTemplate.Extensions;
using StickersTemplate.Models;

namespace StickersTemplate.Cards
{
    public class UserComposeExtensionCard
    {
        private readonly User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="StickerComposeExtensionCard"/> class.
        /// </summary>
        /// <param name="sticker">The <see cref="sticker"/> for this card.</param>
        public UserComposeExtensionCard(User sticker)
        {
            this.user = sticker ?? throw new ArgumentNullException(nameof(sticker));
        }

        /// <summary>
        /// Turns the card into an <see cref="Attachment"/>.
        /// </summary>
        /// <returns>An <see cref="Attachment"/>.</returns>
        public Attachment ToAttachment()
        {
            var content = new UserContentCard(this.user);
            var preview = new UserPreviewCard(this.user);

            return content.ToAttachment().ToComposeExtensionResult(preview.ToAttachment());
        }
    }
}
